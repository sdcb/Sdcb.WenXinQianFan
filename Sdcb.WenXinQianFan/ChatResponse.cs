using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sdcb.WenXinQianFan;

/// <summary>
/// Represents the response of a chat api call.
/// </summary>
public record ChatResponse
{
    /// <summary>
    /// The ID of the current round of chat.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// The type of return package.
    /// "chat.completion": return of multi-round conversation.
    /// </summary>
    [JsonPropertyName("object")]
    public required string Object { get; init; }

    /// <summary>
    /// Timestamp.
    /// </summary>
    [JsonPropertyName("created"), JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public required DateTimeOffset Created { get; init; }

    /// <summary>
    /// Indicates whether the current generation result is truncated.
    /// </summary>
    [JsonPropertyName("is_truncated")]
    public required bool IsTruncated { get; init; }

    /// <summary>
    /// The reason why the generation was finished.
    /// </summary>
    [JsonPropertyName("finish_reason")]
    public string? FinishReason { get; init; }

    /// <summary>
    /// The result returned by the dialogue.
    /// </summary>
    [JsonPropertyName("result")]
    public required string Result { get; init; }

    /// <summary>
    /// Search data. Returned when enable_citation or enable_trace is true and search is triggered.
    /// </summary>
    [JsonPropertyName("search_info")]
    public SearchInfo? SearchInfo { get; init; }

    /// <summary>
    /// Indicates whether there is a security risk in the user's input,
    /// whether to close the current session, and clean up the historical session information.
    /// </summary>
    [JsonPropertyName("need_clear_history")]
    public required bool NeedClearHistory { get; init; }

    /// <summary>
    /// When "need_clear_history" is true, this field will tell which round of chat contains sensitive information.
    /// If it is the current problem, "ban_round" = -1.
    /// </summary>
    [JsonPropertyName("ban_round")]
    public int BanRound { get; init; }

    /// <summary>
    /// Token statistics.
    /// </summary>
    [JsonPropertyName("usage")]
    public required TokensUsage Usage { get; init; }

    /// <summary>
    /// Rate limit information.
    /// </summary>
    public RateLimitInfo RateLimitInfo { get; internal set; } = null!;
}

/// <summary>
/// Represents the response of a streamed chat api call.
/// </summary>
public record StreamedChatResponse : ChatResponse
{
    /// <summary>
    /// Represents the serial number of the current clause. 
    /// This field will only be returned in the streaming interface mode.
    /// </summary>
    [JsonPropertyName("sentence_id")]
    public int SentenceId { get; init; }

    /// <summary>
    /// Indicates whether the current clause is the last one. 
    /// This field will only be returned in the streaming interface mode.
    /// </summary>
    [JsonPropertyName("is_end")]
    public bool IsEnd { get; init; }
}

/// <summary>
/// Represents the search information returned when search is triggered.
/// </summary>
public record SearchInfo
{
    /// <summary>
    /// List of search results.
    /// </summary>
    [JsonPropertyName("search_results")]
    public required SearchResult[] SearchResults { get; set; }
}

/// <summary>
/// Represents a search result.
/// </summary>
public record SearchResult
{
    /// <summary>
    /// The index of the search result.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    /// The URL of the search result.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    /// <summary>
    /// The title of the search result.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }
}