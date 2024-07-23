namespace Sdcb.WenXinQianFan;

/// <summary>
/// <para>Represents the input parameters for the WenXinQianFan assistant.</para>
/// </summary>
public record ChatRequestParameters
{
    /// <summary>
    /// <para>A higher value makes the output more random, while a lower value makes it more focused and determined.</para>
    /// <para>Default is <c>0.8</c>, range is (0, 1.0], it cannot be <c>0</c>.</para>
    /// </summary>
    public float? Temperature { get; set; }

    /// <summary>
    /// <para>Affects the diversity of the output text. The larger the value, the more diverse the generated text.</para>
    /// <para>Default is <c>0.8</c>, range is [0, 1.0].</para>
    /// </summary>
    public float? TopP { get; set; }

    /// <summary>
    /// <para>By adding a penalty to the generated tokens, repetitive generation is reduced.</para>
    /// <para>The larger the value, the greater the penalty. Default is <c>1.0</c>, range is [1.0, 2.0].</para>
    /// </summary>
    public float? PenaltyScore { get; set; }

    /// <summary>
    /// <para>Indicates whether to enable system memory.</para>
    /// <para><c>False</c>: Not enabled, Default is <c>false</c>.</para>
    /// <para><c>True</c>: Enabled, if enabled, system_memory_id must be provided.</para>
    /// </summary>
    public bool? EnableSystemMemory { get; set; }

    /// <summary>
    /// <para>System memory ID, used to read system memory under the corresponding ID.</para>
    /// <para>The retrieved memory text content will be concatenated with the message for request inference.</para>
    /// </summary>
    public string? SystemMemoryId { get; set; }

    /// <summary>
    /// <para>Model's persona, mainly used for persona settings.</para>
    /// <para>For example, you are an AI assistant created by xxx company.</para>
    /// <para>Length limit: the total length of the content in message and system fields cannot exceed 20,000 characters and cannot exceed 5,120 tokens.</para>
    /// </summary>
    public string? System { get; set; }

    /// <summary>
    /// <para>Generation stop markers. When the model's generated result ends with any element in stop, it stops text generation.</para>
    /// <para>Each element's length does not exceed 20 characters, and there can be up to 4 elements.</para>
    /// </summary>
    public string[]? Stop { get; set; }

    /// <summary>
    /// <para>Indicates whether to forcefully close the real-time search function. Default is <c>false</c>, meaning it is not closed.</para>
    /// </summary>
    public bool? DisableSearch { get; set; }

    /// <summary>
    /// <para>Indicates whether to enable superscript return.</para>
    /// <para>If enabled, there is a chance to trigger search source information (search_info).</para>
    /// <para>Default is <c>false</c>, meaning it is not enabled.</para>
    /// </summary>
    public bool? EnableCitation { get; set; }

    /// <summary>
    /// <para>Indicates whether to return search source information.</para>
    /// <para>If enabled, in scenarios where search-enhanced is triggered, search source information (search_info) will be returned.</para>
    /// <para>Default is <c>false</c>, meaning it is not enabled.</para>
    /// </summary>
    public bool? EnableTrace { get; set; }

    /// <summary>
    /// <para>Specifies the maximum number of output tokens for the model.</para>
    /// <para>If this parameter is set, the range is [2, 2048].</para>
    /// <para>If this parameter is not set, the maximum output tokens is <c>1024</c>.</para>
    /// </summary>
    public int? MaxOutputTokens { get; set; }

    /// <summary>
    /// <para>Specifies the format of the response content.</para>
    /// <para>Optional values:</para>
    /// <para>- json_object: returns in JSON format, which may not satisfy the effect in some cases.</para>
    /// <para>- text: returns in text format.</para>
    /// <para>If the parameter response_format is not filled, the default is text.</para>
    /// </summary>
    public string? ResponseFormat { get; set; }

    /// <summary>
    /// <para>Represents the unique identifier of the end user, which can be used to monitor and detect abusive behavior and prevent the interface from being maliciously called.</para>
    /// </summary>
    public string? UserId { get; set; }
}
