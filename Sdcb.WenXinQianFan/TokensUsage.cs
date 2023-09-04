using System.Text.Json.Serialization;

namespace Sdcb.WenXinQianFan;

/// <summary>
/// Represents the usage part of the API payload
/// </summary>
public record TokensUsage
{
    /// <summary>
    /// The count of prompt tokens.
    /// </summary>
    [JsonPropertyName("prompt_tokens")]
    public int PromptTokens { get; set; }

    /// <summary>
    /// The count of completion tokens.
    /// </summary>
    [JsonPropertyName("completion_tokens")]
    public int CompletionTokens { get; set; }

    /// <summary>
    /// The total count of tokens.
    /// </summary>
    [JsonPropertyName("total_tokens")]
    public int TotalTokens { get; set; }
}