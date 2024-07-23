using System.Text.Json.Serialization;

namespace Sdcb.WenXinQianFan;

/// <summary>
/// Represents a chat message object with role and content properties.
/// </summary>
public record ChatMessage(
    [property: JsonPropertyName("role")] string Role,
    [property: JsonPropertyName("content")] string Content
)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChatMessage"/> class with role "user".
    /// </summary>
    /// <param name="content">The message content.</param>
    /// <returns>A new instance of the <see cref="ChatMessage"/> class with role "user".</returns>
    public static ChatMessage FromUser(string content) => new("user", content);

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatMessage"/> class with role "assistant".
    /// </summary>
    /// <param name="content">The message content.</param>
    /// <returns>A new instance of the <see cref="ChatMessage"/> class with role "assistant".</returns>
    public static ChatMessage FromAssistant(string content) => new("assistant", content);
}
