using System.Text.Json.Serialization;

namespace Sdcb.WenXinQianFan;

internal class AuthToken
{
    [JsonPropertyName("refresh_token")]
    public required string RefreshToken { get; set; }

    [JsonPropertyName("expires_in")]
    public required int ExpiresIn { get; set; }

    [JsonPropertyName("session_key")]
    public required string SessionKey { get; set; }

    [JsonPropertyName("access_token")]
    public required string AccessToken { get; set; }

    [JsonPropertyName("scope")]
    public required string Scope { get; set; }

    [JsonPropertyName("session_secret")]
    public required string SessionSecret { get; set; }
}
