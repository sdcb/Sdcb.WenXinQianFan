using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.Json;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace Sdcb.WenXinQianFan;

/// <summary>
/// Defines a class that represents a QianFan API client. This class is responsible for making HTTP calls to the API.
/// </summary>
/// <remarks>
/// This class implements IDisposable because it contains a HttpClient member, which must be disposed when it's no longer needed.
/// </remarks>
public class QianFanClient : IDisposable
{
    private readonly HttpClient _http = new();
    private readonly string _apiKey, _apiSecret;
    private TokenManageContext? _token;

    /// <summary>
    /// Initializes a new instance of the <see cref="QianFanClient"/> class.
    /// </summary>
    /// <param name="apiKey">The API key to use for authentication with the API.</param>
    /// <param name="apiSecret">The API secret to use for authentication with the API.</param>
    public QianFanClient(string apiKey, string apiSecret)
    {
        _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        _apiSecret = apiSecret ?? throw new ArgumentNullException(nameof(apiSecret));
    }

    async Task EnsureAuthToken()
    {
        if (_token == null || !_token.IsValid)
        {
            _token = new TokenManageContext(await CreateAuthTokenAsync(_apiKey, _apiSecret), DateTime.Now);
        }
    }

    internal static async Task<AuthToken> CreateAuthTokenAsync(string apiKey, string apiSecret, CancellationToken cancellationToken = default)
    {
        using HttpClient http = new();
        string apiUri = $"https://aip.baidubce.com/oauth/2.0/token?grant_type=client_credentials&client_id={apiKey}&client_secret={apiSecret}";
        HttpResponseMessage resp = await http.GetAsync(apiUri, cancellationToken);

        if (resp.IsSuccessStatusCode)
        {
            AuthToken? token = await resp.Content.ReadFromJsonAsync<AuthToken>(cancellationToken: cancellationToken);
            return token ?? throw new Exception($"Unable to deserialize '{await resp.Content.C_ReadAsStringAsync(cancellationToken)}' into {nameof(AuthToken)}.");
        }
        else
        {
            throw new HttpRequestException($"{resp.ReasonPhrase}: {await resp.Content.C_ReadAsStringAsync(cancellationToken)}");
        }
    }

    /// <summary>
    /// Sends a chat message to the API and retrieves the response.
    /// </summary>
    /// <param name="model">The model to use for the chat.</param>
    /// <param name="messages">The messages to send to the chat.</param>
    /// <param name="options">The options to configure the chat call.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>Returns a <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<ChatResponse> ChatAsync(KnownModel model, IEnumerable<ChatMessage> messages, ChatRequestParameters? options = null, CancellationToken cancellationToken = default)
    {
        await EnsureAuthToken();

        StringContent jsonContent = new(JsonSerializer.Serialize(InternalChatRequest.FromOptions(messages, options, stream: false)), Encoding.UTF8, "application/json");

        HttpResponseMessage resp = await _http.PostAsync($"{model.Url}?access_token={_token!.Token.AccessToken}", jsonContent, cancellationToken);
        RateLimitInfo rateLimitInfo = RateLimitInfo.ParseHeaders(resp.Headers);

        if (resp.IsSuccessStatusCode)
        {
            ChatResponse? result = await resp.Content.C_ReadFromJsonAsync<ChatResponse>(cancellationToken)
                ?? throw new Exception($"Unable to deserialize '{await resp.Content.C_ReadAsStringAsync(cancellationToken)}' into {nameof(ChatResponse)}.");
            result.RateLimitInfo = rateLimitInfo;
            return result;
        }
        else
        {
            throw new HttpRequestException($"{resp.ReasonPhrase}: {await resp.Content.C_ReadAsStringAsync(cancellationToken)}");
        }
    }

    /// <summary>
    /// Streams chat messages to the API and retrieves the responses.
    /// </summary>
    /// <param name="model">The model to use for the chat.</param>
    /// <param name="messages">The messages to send to the chat.</param>
    /// <param name="options">The options to configure the chat call.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>Returns an asynchronous sequence of <see cref="ChatResponse"/>.</returns>
    public async IAsyncEnumerable<StreamedChatResponse> ChatAsStreamAsync(KnownModel model, IEnumerable<ChatMessage> messages, ChatRequestParameters? options = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await EnsureAuthToken();

        HttpResponseMessage resp = await _http.SendAsync(new HttpRequestMessage(HttpMethod.Post, $"{model.Url}?access_token={_token!.Token.AccessToken}")
        {
            Content = new StringContent(JsonSerializer.Serialize(InternalChatRequest.FromOptions(messages, options, stream: true)))
        }, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

        RateLimitInfo rateLimitInfo = RateLimitInfo.ParseHeaders(resp.Headers);

        if (resp.IsSuccessStatusCode)
        {
            using Stream stream = await resp.Content.C_ReadAsStreamAsync(cancellationToken);
            using StreamReader reader = new(stream);

            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (line.StartsWith("data: ", StringComparison.Ordinal))
                {
                    string json = line[6..];
                    StreamedChatResponse result = JsonSerializer.Deserialize<StreamedChatResponse>(json) 
                        ?? throw new Exception($"Unable to deserialize '{await resp.Content.C_ReadAsStringAsync(cancellationToken)}' into {nameof(StreamedChatResponse)}.");
                    result.RateLimitInfo = rateLimitInfo;
                    yield return result;
                }
                else if (!string.IsNullOrWhiteSpace(line))
                {
                    throw new HttpRequestException(line);
                }
            }
        }
        else
        {
            throw new HttpRequestException($"{resp.ReasonPhrase}: {await resp.Content.C_ReadAsStringAsync(cancellationToken)}");
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        _http.Dispose();
        GC.SuppressFinalize(this);
    }
}
