using System.Linq;
using System;
using System.Net.Http.Headers;

namespace Sdcb.WenXinQianFan;

/// <summary>
/// Represents rate limit information for requests and tokens.
/// </summary>
public record RateLimitInfo
{
    /// <summary>
    /// Gets or sets the maximum number of requests allowed per minute.
    /// </summary>
    public required int LimitRequests { get; init; }

    /// <summary>
    /// Gets or sets the maximum number of tokens that can be consumed per minute, 
    /// including both input and output tokens.
    /// </summary>
    public required int LimitTokens { get; init; }

    /// <summary>
    /// Gets or sets the remaining number of requests that can be sent before 
    /// reaching the requests per minute (RPM) rate limit. If the quota is exhausted, 
    /// it will refresh within 0-60 seconds.
    /// </summary>
    public required int RemainingRequests { get; init; }

    /// <summary>
    /// Gets or sets the remaining number of tokens that can be consumed before 
    /// reaching the tokens per minute (TPM) rate limit. If the quota is exhausted, 
    /// it will refresh within 0-60 seconds.
    /// </summary>
    public required int RemainingTokens { get; init; }

    /// <summary>
    /// Parses the rate limit information from the provided HTTP response headers.
    /// </summary>
    /// <param name="headers">The HTTP response headers to parse.</param>
    /// <returns>A <see cref="RateLimitInfo"/> instance populated with the parsed values.</returns>
    /// <exception cref="ArgumentNullException">Thrown if headers is null.</exception>
    /// <exception cref="FormatException">Thrown if any header value cannot be parsed to an integer.</exception>
    public static RateLimitInfo ParseHeaders(HttpResponseHeaders headers)
    {
        if (headers == null)
            throw new ArgumentNullException(nameof(headers));

        if (!headers.TryGetValues("X-Ratelimit-Limit-Requests", out var limitRequestsValues) ||
            !int.TryParse(limitRequestsValues.FirstOrDefault(), out var limitRequests))
        {
            throw new FormatException("Cannot parse X-Ratelimit-Limit-Requests header.");
        }

        if (!headers.TryGetValues("X-Ratelimit-Limit-Tokens", out var limitTokensValues) ||
            !int.TryParse(limitTokensValues.FirstOrDefault(), out var limitTokens))
        {
            throw new FormatException("Cannot parse X-Ratelimit-Limit-Tokens header.");
        }

        if (!headers.TryGetValues("X-Ratelimit-Remaining-Requests", out var remainingRequestsValues) ||
            !int.TryParse(remainingRequestsValues.FirstOrDefault(), out var remainingRequests))
        {
            throw new FormatException("Cannot parse X-Ratelimit-Remaining-Requests header.");
        }

        if (!headers.TryGetValues("X-Ratelimit-Remaining-Tokens", out var remainingTokensValues) ||
            !int.TryParse(remainingTokensValues.FirstOrDefault(), out var remainingTokens))
        {
            throw new FormatException("Cannot parse X-Ratelimit-Remaining-Tokens header.");
        }

        return new RateLimitInfo
        {
            LimitRequests = limitRequests,
            LimitTokens = limitTokens,
            RemainingRequests = remainingRequests,
            RemainingTokens = remainingTokens
        };
    }
}
