using System.Text.Json.Serialization;

namespace Sdcb.WenXinQianFan;

/// <summary>
/// Represents the response of a chat api call.
/// </summary>
public class ChatResponse
{
    /// <summary>
    /// The ID of the current round of chat.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The type of return package.
    /// "chat.completion": return of multi-round conversation.
    /// </summary>
    [JsonPropertyName("object")]
    public required string Object { get; set; }

    /// <summary>
    /// Timestamp.
    /// </summary>
    [JsonPropertyName("created")]
    public long Created { get; set; }

    /// <summary>
    /// Represents the serial number of the current clause. 
    /// This field will only be returned in the streaming interface mode.
    /// </summary>
    [JsonPropertyName("sentence_id")]
    public int SentenceId { get; set; }

    /// <summary>
    /// Indicates whether the current generation result is truncated.
    /// </summary>
    [JsonPropertyName("is_truncated")]
    public bool IsTruncated { get; set; }

    /// <summary>
    /// The result returned by the dialogue.
    /// </summary>
    [JsonPropertyName("result")]
    public required string Result { get; set; }

    /// <summary>
    /// Indicates whether there is a security risk in the user's input, 
    /// whether to close the current session, and clean up the historical session information.
    /// </summary>
    [JsonPropertyName("need_clear_history")]
    public bool NeedClearHistory { get; set; }

    /// <summary>
    /// When "need_clear_history" is true, this field will tell which round of chat contains sensitive information.
    /// If it is the current problem, "ban_round" = -1.
    /// </summary>
    [JsonPropertyName("ban_round")]
    public int BanRound { get; set; }

    /// <summary>
    /// Token statistics. The number of tokens = the number of Chinese characters + the number of words * 1.3 (only for estimation logic).
    /// </summary>
    [JsonPropertyName("usage")]
    public required TokensUsage Usage { get; set; }
}

/// <summary>
/// Represents the response of a streamed chat api call.
/// </summary>
public class StreamedChatResponse : ChatResponse
{
    /// <summary>
    /// Indicates whether the current clause is the last one. 
    /// This field will only be returned in the streaming interface mode.
    /// </summary>
    [JsonPropertyName("is_end")]
    public bool IsEnd { get; set; }
}