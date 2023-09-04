namespace Sdcb.WenXinQianFan;

/// <summary>
/// Represents a known language model with a name and a url for communication.
/// </summary>
public record KnownModel(string Name, string Url)
{

    private const string BaseUrl = "https://aip.baidubce.com/rpc/2.0/ai_custom/v1/wenxinworkshop/chat/";

    /// <summary>ERNIE-Bot is a large language model developed by Baidu, covering a large amount of Chinese data, with stronger capabilities in dialogue QA, content creation generation, etc.</summary>
    public static KnownModel ERNIEBot => new KnownModel("ERNIE-Bot", BaseUrl + "completions");

    /// <summary>ERNIE-Bot-turbo is a large language model developed by Baidu, covering a large amount of Chinese data, with stronger capabilities in dialogue QA, content creation generation, etc., and faster response speed.</summary>
    public static KnownModel ERNIEBotTurbo => new KnownModel("ERNIE-Bot-turbo", BaseUrl + "eb-instant");

    /// <summary>BLOOMZ-7B is a well-known large language model developed and open-sourced by BigScience, capable of outputting text in 46 languages and 13 programming languages.</summary>
    public static KnownModel BLOOMZ_7B => new KnownModel("BLOOMZ-7B", BaseUrl + "bloomz_7b1");

    /// <summary>Llama-2-7b-chat is developed and open-sourced by Meta AI, performing excellently in encoding, inference, and knowledge application scenarios.</summary>
    public static KnownModel Llama2_7bChat => new KnownModel("Llama-2-7b-chat", BaseUrl + "llama_2_7b");

    /// <summary>Llama-2-13b-chat is developed and open-sourced by Meta AI, performing excellently in encoding, inference, and knowledge application scenarios. Llama-2-13b-chat is a native open-source version with balanced performance and effects.</summary>
    public static KnownModel Llama2_13bChat => new KnownModel("Llama-2-13b-chat", BaseUrl + "llama_2_13b");

    /// <summary>Llama-2-70b-chat is developed and open-sourced by Meta AI, performing excellently in encoding, inference, and knowledge application scenarios. Llama-2-70b-chat is a high-precision native open-source version.</summary>
    public static KnownModel Llama2_70bChat => new KnownModel("Llama-2-70b-chat", BaseUrl + "llama_2_70b");

    /// <summary>Qianfan-BLOOMZ-7B-compressed is a compressed version of BLOOMZ-7B by the Qianfan team, integrating quantization and sparsification technologies, reducing memory occupancy by over 30%.</summary>
    public static KnownModel QianfanBLOOMZ_7BCompressed => new KnownModel("Qianfan-BLOOMZ-7B-compressed", BaseUrl + "qianfan_bloomz_7b_compressed");

    /// <summary>Qianfan-Chinese-Llama-2-7B is a Chinese-enhanced version of Llama-2-7b by the Qianfan team, performing excellently on Chinese datasets such as CMMLU and C-EVAL.</summary>
    public static KnownModel QianfanChineseLlama2_7B => new KnownModel("Qianfan-Chinese-Llama-2-7B", BaseUrl + "qianfan_chinese_llama_2_7b");

    /// <summary>ChatGLM2-6B-32K further strengthens the understanding of long texts based on ChatGLM2-6B, and can better handle a context of up to 32K in length.</summary>
    public static KnownModel ChatGLM2_6B_32K => new KnownModel("ChatGLM2-6B-32K", BaseUrl + "chatglm2_6b_32k");

    /// <summary>AquilaChat-7B is a dialogue model trained by Zhiyuan Research Institute based on Aquila-7B, supporting smooth text dialogue and various language-type generative tasks, and can call other models and tools through definable and expandable special instruction specifications.</summary>
    public static KnownModel AquilaChat_7B => new KnownModel("AquilaChat-7B", BaseUrl + "aquilachat_7b");
}
