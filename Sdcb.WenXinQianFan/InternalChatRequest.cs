using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sdcb.WenXinQianFan;

/// <summary>
/// Represents the input parameters for the WenXinQianFan assistant.
/// </summary>
internal class InternalChatRequest
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
            UserId = options?.UserId
        };
    }

    /// <summary>
    /// Chat context information. It cannot be empty. One member represents a single round of conversation, and multiple members represent multiple rounds of conversation.
    /// The last message is the information of the current request, and the previous messages are historical conversation information.
    /// There must be an odd number of members, and the role of the messages must be in the order of user, assistant.
    /// The content length of the last message (i.e., the question of this round of conversation) cannot exceed 11200 characters; if the total content length in messages exceeds 11200 characters, the system will forget the earliest historical conversations until the total content length does not exceed 11200 characters.
    /// </summary>
    [JsonPropertyName("messages")]
    public required IEnumerable<ChatMessage> Messages { get; set; }

    /// <summary>
    /// Whether to return data in the form of a streaming interface, default is false.
    /// </summary>
    [JsonPropertyName("stream")]
    public bool? Stream { get; set; }

    /// <summary>
    /// A higher value makes the output more random, while a lower value makes it more focused and determined. The default is 0.95, the range is (0, 1.0], it cannot be 0.
    /// It is recommended to set only one of this parameter and top_p, and it is recommended not to change top_p and temperature simultaneously.
    /// </summary>
    [JsonPropertyName("temperature")]
    public float? Temperature { get; set; }

    /// <summary>
    /// Affects the diversity of the output text. The larger the value, the more diverse the generated text. The default is 0.8, the range is [0, 1.0].
    /// It is recommended to set only one of this parameter and temperature, and it is recommended not to change top_p and temperature simultaneously.
    /// </summary>
    [JsonPropertyName("top_p")]
    public float? TopP { get; set; }

    /// <summary>
    /// By adding a penalty to the generated tokens, repetitive generation is reduced. The larger the value, the greater the penalty. The default is 1.0, the range is [1.0, 2.0].
    /// </summary>
    [JsonPropertyName("penalty_score")]
    public float? PenaltyScore { get; set; }

    /// <summary>
    /// Represents the unique identifier of the end user, which can be used to monitor and detect abusive behavior and prevent the interface from being maliciously called.
    /// </summary>
    [JsonPropertyName("user_id")]
    public string? UserId { get; set; }
}
