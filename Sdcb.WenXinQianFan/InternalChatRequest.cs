using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sdcb.WenXinQianFan;

/// <summary>
/// Represents the input parameters for the WenXinQianFan assistant.
/// </summary>
internal record InternalChatRequest
{
    internal static InternalChatRequest FromOptions(IEnumerable<ChatMessage> messages, ChatRequestParameters? options, bool stream)
    {
        return new InternalChatRequest
        {
            Messages = messages,
            Stream = stream,
            Temperature = options?.Temperature,
            TopP = options?.TopP,
            PenaltyScore = options?.PenaltyScore,
            UserId = options?.UserId,
            EnableSystemMemory = options?.EnableSystemMemory,
            SystemMemoryId = options?.SystemMemoryId,
            System = options?.System,
            Stop = options?.Stop,
            DisableSearch = options?.DisableSearch,
            EnableCitation = options?.EnableCitation,
            EnableTrace = options?.EnableTrace,
            MaxOutputTokens = options?.MaxOutputTokens,
            ResponseFormat = options?.ResponseFormat
        };
    }

    /// <summary>
    /// Chat context information. It cannot be empty. One member represents a single round of conversation, and multiple members represent multiple rounds of conversation.
    /// The last message is the information of the current request, and the previous messages are historical conversation information.
    /// There must be an odd number of members, and the role of the messages must be in the order of user, assistant.
    /// The total content length in messages cannot exceed 20000 characters, and not exceed 5120 tokens.
    /// </summary>
    [JsonPropertyName("messages")]
    public required IEnumerable<ChatMessage> Messages { get; set; }

    /// <summary>
    /// Whether to return data in the form of a streaming interface, default is false.
    /// </summary>
    [JsonPropertyName("stream"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Stream { get; set; }

    /// <summary>
    /// A higher value makes the output more random, while a lower value makes it more focused and determined. The default is 0.8, the range is (0, 1.0], it cannot be 0.
    /// </summary>
    [JsonPropertyName("temperature"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? Temperature { get; set; }

    /// <summary>
    /// Affects the diversity of the output text. The larger the value, the more diverse the generated text. The default is 0.8, the range is [0, 1.0].
    /// </summary>
    [JsonPropertyName("top_p"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? TopP { get; set; }

    /// <summary>
    /// By adding a penalty to the generated tokens, repetitive generation is reduced. The larger the value, the greater the penalty. The default is 1.0, the range is [1.0, 2.0].
    /// </summary>
    [JsonPropertyName("penalty_score"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? PenaltyScore { get; set; }

    /// <summary>
    /// Represents the unique identifier of the end user, which can be used to monitor and detect abusive behavior and prevent the interface from being maliciously called.
    /// </summary>
    [JsonPropertyName("user_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? UserId { get; set; }

    /// <summary>
    /// Whether to enable system memory. Default is false.
    /// </summary>
    [JsonPropertyName("enable_system_memory"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? EnableSystemMemory { get; set; }

    /// <summary>
    /// System memory ID, required if enable_system_memory is true.
    /// </summary>
    [JsonPropertyName("system_memory_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SystemMemoryId { get; set; }

    /// <summary>
    /// Model persona, mainly used for persona settings such as "You are an AI assistant created by xxx company".
    /// </summary>
    [JsonPropertyName("system"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? System { get; set; }

    /// <summary>
    /// Generation stop markers. When the model generates a result that ends with one of the elements in stop, it stops the text generation.
    /// </summary>
    [JsonPropertyName("stop"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? Stop { get; set; }

    /// <summary>
    /// Whether to forcefully disable real-time search functionality. Default is false (not disabled).
    /// </summary>
    [JsonPropertyName("disable_search"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DisableSearch { get; set; }

    /// <summary>
    /// Whether to enable superscript return. Default is false (not enabled).
    /// </summary>
    [JsonPropertyName("enable_citation"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? EnableCitation { get; set; }

    /// <summary>
    /// Whether to return search trace information. Default is false (not enabled).
    /// </summary>
    [JsonPropertyName("enable_trace"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? EnableTrace { get; set; }

    /// <summary>
    /// Specifies the maximum number of tokens the model can output. Default is 1024, range is [2, 2048].
    /// </summary>
    [JsonPropertyName("max_output_tokens"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxOutputTokens { get; set; }

    /// <summary>
    /// Specifies the format of the response content.
    /// </summary>
    [JsonPropertyName("response_format"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ResponseFormat { get; set; }
}