namespace Sdcb.WenXinQianFan;

/// <summary>
/// Represents the input parameters for the WenXinQianFan assistant.
/// </summary>
public class ChatRequestParameters
{
    /// <summary>
    /// A higher value makes the output more random, while a lower value makes it more focused and determined. The default is 0.95, the range is (0, 1.0], it cannot be 0.
    /// It is recommended to set only one of this parameter and top_p, and it is recommended not to change top_p and temperature simultaneously.
    /// </summary>
    public float? Temperature { get; set; }

    /// <summary>
    /// Affects the diversity of the output text. The larger the value, the more diverse the generated text. The default is 0.8, the range is [0, 1.0].
    /// It is recommended to set only one of this parameter and temperature, and it is recommended not to change top_p and temperature simultaneously.
    /// </summary>
    public float? TopP { get; set; }

    /// <summary>
    /// By adding a penalty to the generated tokens, repetitive generation is reduced. The larger the value, the greater the penalty. The default is 1.0, the range is [1.0, 2.0].
    /// </summary>
    public float? PenaltyScore { get; set; }

    /// <summary>
    /// Represents the unique identifier of the end user, which can be used to monitor and detect abusive behavior and prevent the interface from being maliciously called.
    /// </summary>
    public string? UserId { get; set; }
}
