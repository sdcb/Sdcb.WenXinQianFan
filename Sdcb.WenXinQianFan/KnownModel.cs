namespace Sdcb.WenXinQianFan;

/// <summary>
/// Represents a model from QianFan with an ID and display name.
/// </summary>
/// <param name="Id">The identifier of the model.</param>
/// <param name="DisplayName">The display name of the model.</param>
public record KnownModel(string Id, string? DisplayName = null)
{
    /// <summary>
    /// The URL of the model.
    /// </summary>
    public virtual string Url { get; } = $"https://aip.baidubce.com/rpc/2.0/ai_custom/v1/wenxinworkshop/chat/{Id}";

    /// <summary>
    /// Baidu's flagship self-developed large-scale language model, with comprehensive model capability upgrades compared to ERNIE 3.5. It is widely applicable to complex task scenarios in various fields; supports automatic docking with Baidu search plugins to ensure the timeliness of Q&amp;A information. The most powerful language model in Baidu's Wenxin series, with top-level understanding, generation, logic, and memory capabilities.
    /// </summary>
    public static KnownModel ERNIE_40_8K { get; } = new("completions_pro", "ERNIE-4.0-8K");

    /// <summary>
    /// Baidu's flagship self-developed large-scale language model, with comprehensive model capability upgrades compared to ERNIE 3.5. It is widely applicable to complex task scenarios in various fields; supports automatic docking with Baidu search plugins to ensure the timeliness of Q&amp;A information.
    /// </summary>
    public static KnownModel ERNIE_40_8K_Preview { get; } = new("ernie-4.0-8k-preview", "ERNIE-4.0-8K-Preview");

    /// <summary>
    /// Baidu's flagship self-developed large-scale language model, with comprehensive model capability upgrades compared to ERNIE-4.0-8K. Role-playing and instruction-following capabilities have been significantly enhanced. Widely applicable to complex task scenarios in various fields; supports automatic docking with Baidu search plugins to ensure the timeliness of Q&amp;A information.
    /// </summary>
    public static KnownModel ERNIE_40_8K_Preview_0518 { get; } = new("completions_adv_pro", "ERNIE-4.0-8K-Preview-0518");

    /// <summary>
    /// Compared to ERNIE-4.0-8K, ERNIE-4.0-8K-Latest has comprehensive capability upgrades, with significant improvements in role-playing and instruction-following capabilities. Applicable to various complex task scenarios; supports automatic docking with Baidu search plugins to ensure Q&amp;A information timeliness, and supports 5K tokens input + 2K tokens output.
    /// </summary>
    public static KnownModel ERNIE_40_8K_Latest { get; } = new("ernie-4.0-8k-latest", "ERNIE-4.0-8K-Latest");

    /// <summary>
    /// Baidu's flagship self-developed large-scale language model, with comprehensive model capability upgrades compared to ERNIE 3.5. Widely applicable to complex task scenarios in various fields; the most powerful language model in Baidu's Wenxin series, with top-level understanding, generation, logic, and memory capabilities. This version was updated and released on March 29, 2024, with further enhancements in model performance.
    /// </summary>
    public static KnownModel ERNIE_40_8K_0329 { get; } = new("ernie-4.0-8k-0329", "ERNIE-4.0-8K-0329");

    /// <summary>
    /// Baidu's flagship self-developed large-scale language model, with comprehensive model capability upgrades compared to ERNIE 3.5. Widely applicable to complex task scenarios in various fields; supports automatic docking with Baidu search plugins to ensure the timeliness of Q&amp;A information, and supports 5K tokens input + 2K tokens output.
    /// </summary>
    public static KnownModel ERNIE_40_8K_0613 { get; } = new("ernie-4.0-8k-0613", "ERNIE-4.0-8K-0613");

    /// <summary>
    /// ERNIE 4.0 Turbo is Baidu's flagship self-developed large-scale language model, with excellent overall performance, suitable for various complex task scenarios; supports automatic docking with Baidu search plugins to ensure the timeliness of Q&amp;A information. Compared to ERNIE 4.0, it performs better. ERNIE-4.0-Turbo-8K is the model version first released on June 28, 2024.
    /// </summary>
    public static KnownModel ERNIE_40_Turbo_8K { get; } = new("ernie-4.0-turbo-8k", "ERNIE-4.0-Turbo-8K");

    /// <summary>
    /// ERNIE 4.0 Turbo is Baidu's flagship self-developed large-scale language model, with excellent overall performance, suitable for various complex task scenarios; supports automatic docking with Baidu search plugins to ensure the timeliness of Q&amp;A information. Compared to ERNIE 4.0, it performs better. ERNIE-4.0-Turbo-8K-Preview is a version of the model.
    /// </summary>
    public static KnownModel ERNIE_40_Turbo_8K_Preview { get; } = new("ernie-4.0-turbo-8k-preview", "ERNIE-4.0-Turbo-8K-Preview");

    /// <summary>
    /// Baidu's flagship large-scale language model, covering massive Chinese and English corpora, with powerful general capabilities, can meet most dialogue Q&amp;A, creative generation, and plugin application scenario requirements; supports automatic docking with Baidu search plugins to ensure the timeliness of Q&amp;A information.
    /// </summary>
    public static KnownModel ERNIE_35_8K { get; } = new("completions", "ERNIE-3.5-8K");

    /// <summary>
    /// Baidu's flagship large-scale language model, covering massive Chinese and English corpora, with powerful general capabilities, can meet most dialogue Q&amp;A, creative generation, and plugin application scenario requirements; supports automatic docking with Baidu search plugins to ensure the timeliness of Q&amp;A information.
    /// </summary>
    public static KnownModel ERNIE_35_8K_Preview { get; } = new("ernie-3.5-8k-preview", "ERNIE-3.5-8K-Preview");

    /// <summary>
    /// Baidu's flagship large-scale language model, covering massive Chinese and English corpora, with powerful general capabilities, can meet most dialogue Q&amp;A, creative generation, and plugin application scenario requirements; supports automatic docking with Baidu search plugins to ensure the timeliness of Q&amp;A information.
    /// </summary>
    public static KnownModel ERNIE_35_8K_0329 { get; } = new("ernie-3.5-8k-0329", "ERNIE-3.5-8K-0329");

    /// <summary>
    /// ERNIE 3.5 is Baidu's flagship large-scale language model, covering massive Chinese and English corpora, with powerful general capabilities, can meet most dialogue Q&amp;A, creative generation, and plugin application scenario requirements; supports automatic docking with Baidu search plugins to ensure the timeliness of Q&amp;A information. ERNIE-3.5-128K is a version of the model, released on May 16, 2024, enhancing context window length to 128K.
    /// </summary>
    public static KnownModel ERNIE_35_128K { get; } = new("ernie-3.5-128k", "ERNIE-3.5-128K");

    /// <summary>
    /// Baidu's flagship large-scale language model, covering massive Chinese and English corpora, with powerful general capabilities, can meet most dialogue Q&amp;A, creative generation, and plugin application scenario requirements; supports automatic docking with Baidu search plugins to ensure the timeliness of Q&amp;A information.
    /// </summary>
    public static KnownModel ERNIE_35_8K_0613 { get; } = new("ernie-3.5-8k-0613", "ERNIE-3.5-8K-0613");

    /// <summary>
    /// Baidu's latest self-developed high-performance large language model released in 2024, with excellent general capabilities, suitable as a base model for fine-tuning to better handle specific scenario problems, and excellent inferencing performance.
    /// </summary>
    public static KnownModel ERNIE_Speed_8K { get; } = new("ernie_speed", "ERNIE-Speed-8K");

    /// <summary>
    /// Baidu's latest self-developed high-performance large language model released in 2024, with excellent general capabilities, suitable as a base model for fine-tuning to better handle specific scenario problems, and excellent inferencing performance. This service is a preview version and does not guarantee SLA.
    /// </summary>
    public static KnownModel ERNIE_Speed_128K { get; } = new("ernie-speed-128k", "ERNIE-Speed-128K");

    /// <summary>
    /// Baidu's self-developed vertical scene large language model, suitable for applications such as game NPCs, customer service conversations, dialogue role-playing, etc., with more distinctive and consistent character styles, stronger instruction-following capabilities, and better inferencing performance.
    /// </summary>
    public static KnownModel ERNIE_Character_8K { get; } = new("ernie-char-8k", "ERNIE-Character-8K");

    /// <summary>
    /// Baidu's self-developed vertical scene large language model, suitable for applications such as game NPCs, customer service conversations, dialogue role-playing, etc., with more distinctive and consistent character styles, stronger instruction-following capabilities, and better inferencing performance.
    /// </summary>
    public static KnownModel ERNIE_Character_Fiction_8K { get; } = new("ernie-char-fiction-8k", "ERNIE-Character-Fiction-8K");

    /// <summary>
    /// Baidu's self-developed lightweight large language model, balancing excellent model performance and inferencing capabilities, suitable for low-power AI accelerated card inferencing use.
    /// </summary>
    public static KnownModel ERNIE_Lite_8K { get; } = new("ernie-lite-8k", "ERNIE-Lite-8K");

    /// <summary>
    /// ERNIE-Lite is Baidu's self-developed lightweight large language model, balancing excellent model performance and inferencing capabilities, suitable for low-power AI accelerated card inferencing use.
    /// </summary>
    public static KnownModel ERNIE_Lite_8K_0922 { get; } = new("eb-instant", "ERNIE-Lite-8K-0922");

    /// <summary>
    /// Baidu's self-developed vertical scene large language model, suitable for scenarios such as Q&amp;A using external tools and business function calls, with stronger structured answer synthesis capabilities, more stable output formats, and better inferencing performance.
    /// </summary>
    public static KnownModel ERNIE_Functions_8K_0321 { get; } = new("ernie-func-8k", "ERNIE-Functions-8K-0321");

    /// <summary>
    /// Baidu's self-developed ultra-high-performance large language model with the lowest deployment and fine-tuning costs among the Wenxin series models.
    /// </summary>
    public static KnownModel ERNIE_Tiny_8K { get; } = new("ernie-tiny-8k", "ERNIE-Tiny-8K");

    /// <summary>
    /// A specialized version of the model for Qianfan AppBuilder, optimized for enterprise-level large model applications. It achieves better performance under the same scale model for Q&amp;A and intelligent agent-related scenarios, and is used with "Baidu Smart Cloud Qianfan AppBuilder" product or combined with "AppBuilder-SDK" for independent use.
    /// </summary>
    public static KnownModel ERNIE_Speed_AppBuilder_8K { get; } = new("ai_apaas", "ERNIE-Speed-AppBuilder-8K");

    /// <summary>
    /// The version released on June 14, 2024, supports 8K context length and has been quantized and compressed using INT8-PTQ.
    /// </summary>
    public static KnownModel ERNIE_Lite_AppBuilder_8K_0614 { get; } = new("ai_apaas_lite", "ERNIE-Lite-AppBuilder-8K-0614");

    /// <summary>
    /// Google developed a series of lightweight, cutting-edge open-source text generation models built with the same technology as the Gemini model. They are suitable for various text generation tasks and can be deployed on resource-constrained edge devices.
    /// </summary>
    public static KnownModel Gemma_7B_it { get; } = new("gemma_7b_it", "Gemma-7B-it");

    /// <summary>
    /// A bilingual large language model developed and open sourced by Zero-One Everything, trained with a 4K sequence length and expandable up to 32K during inference; it leads in multiple evaluations globally, achieving several state-of-the-art international best performance metrics. This version supports chat functionality.
    /// </summary>
    public static KnownModel Yi_34B_Chat { get; } = new("yi_34b_chat", "Yi-34B-Chat");

    /// <summary>
    /// BLOOMZ-7B is a well-known large language model in the industry, developed and open-sourced by BigScience, capable of generating text in 46 languages and 13 programming languages.
    /// </summary>
    public static KnownModel BLOOMZ_7B { get; } = new("bloomz_7b1", "BLOOMZ-7B");

    /// <summary>
    /// A compressed version of BLOOMZ-7B by the Qianfan team, integrating quantization and sparsification technologies, reducing memory usage by more than 30%.
    /// </summary>
    public static KnownModel Qianfan_BLOOMZ_7B_compressed { get; } = new("qianfan_bloomz_7b_compressed", "Qianfan-BLOOMZ-7B-compressed");

    /// <summary>
    /// The first high-quality sparse mixture of experts (MOE) model released by Mistral AI, consisting of eight 7B parameter expert models, outperforming Llama-2-70B and GPT3.5 in multiple benchmarks, capable of handling 32K context, and performing particularly well in code generation tasks.
    /// </summary>
    public static KnownModel Mixtral_8x7B_Instruct { get; } = new("mixtral_8x7b_instruct", "Mixtral-8x7B-Instruct");

    /// <summary>
    /// Llama-2-7b-chat, developed and open-sourced by Meta AI, performs excellently in scenarios such as coding, inference, and knowledge application. Llama-2-7b-chat is a high-performance native open-source version suitable for dialogue scenarios.
    /// </summary>
    public static KnownModel Llama_2_7B_chat { get; } = new("llama_2_7b", "Llama-2-7b-chat");

    /// <summary>
    /// Llama-2-13b-chat, developed and open-sourced by Meta AI, performs excellently in scenarios such as coding, inference, and knowledge application. Llama-2-13b-chat is a balanced native open-source version in terms of performance and effect, suitable for dialogue scenarios.
    /// </summary>
    public static KnownModel Llama_2_13B_chat { get; } = new("llama_2_13b", "Llama-2-13b-chat");

    /// <summary>
    /// Llama-2-70b-chat, developed and open-sourced by Meta AI, performs excellently in scenarios such as coding, inference, and knowledge application. Llama-2-70b-chat is a high-accuracy native open-source version.
    /// </summary>
    public static KnownModel Llama_2_70B_chat { get; } = new("llama_2_70b", "Llama-2-70b-chat");

    /// <summary>
    /// Meta-Llama-3-8B is an 8B parameter model from the Meta Llama 3 series released by Meta AI on April 18, 2024, adept at language nuances, context understanding, code generation, and tasks such as translation and dialogue generation. Meta-Llama-3-8B-Instruct is an 8B parameter instruction-tuned version suitable for dialogue scenarios, outperforming many available open-source chat models on common industry benchmarks.
    /// </summary>
    public static KnownModel Meta_Llama_3_8B_Instruct { get; } = new("llama_3_8b", "Meta-Llama-3-8B-Instruct");

    /// <summary>
    /// Meta-Llama-3-70B is a 70B parameter model from the Meta Llama 3 series released by Meta AI on April 18, 2024, adept at language nuances, context understanding, code generation, and tasks such as translation and dialogue generation. Meta-Llama-3-70B-Instruct is a 70B parameter instruction-tuned version suitable for dialogue scenarios, with improved performance in understanding language details, context, and executing complex tasks.
    /// </summary>
    public static KnownModel Meta_Llama_3_70B_Instruct { get; } = new("llama_3_70b", "Meta-Llama-3-70B-Instruct");

    /// <summary>
    /// A Chinese-enhanced version based on Llama-2-7b by the Qianfan team, performing well on Chinese datasets such as CMMLU and C-EVAL.
    /// </summary>
    public static KnownModel Qianfan_Chinese_Llama_2_7B { get; } = new("qianfan_chinese_llama_2_7b", "Qianfan-Chinese-Llama-2-7B");

    /// <summary>
    /// A Chinese-enhanced version based on Llama-2-13b by the Qianfan team, performing well on Chinese datasets such as CMMLU and C-EVAL.
    /// </summary>
    public static KnownModel Qianfan_Chinese_Llama_2_13B_v1 { get; } = new("qianfan_chinese_llama_2_13b", "Qianfan-Chinese-Llama-2-13B-v1");

    /// <summary>
    /// A Chinese-enhanced version based on Llama-2-70b by the Qianfan team, performing well on Chinese datasets such as CMMLU and C-EVAL.
    /// </summary>
    public static KnownModel Qianfan_Chinese_Llama_2_70B { get; } = new("qianfan_chinese_llama_2_70b", "Qianfan-Chinese-Llama-2-70B");

    /// <summary>
    /// Based on ChatGLM2-6B, further strengthens the ability to understand long texts, better handling up to 32K length contexts.
    /// </summary>
    public static KnownModel ChatGLM2_6B_32K { get; } = new("chatglm2_6b_32k", "ChatGLM2-6B-32K");

    /// <summary>
    /// Developed by Du Xiaoman, based on the Llama2-70B model, enhanced for the financial industry with significantly improved capabilities in various Chinese benchmarks such as CMMLU and C-EVAL; excels in financial domain tasks, supporting financial knowledge Q&amp;A, financial calculations, and financial analysis. This version supports 4-bit quantization.
    /// </summary>
    public static KnownModel XuanYuan_70B_Chat_4bit { get; } = new("xuanyuan_70b_chat", "XuanYuan-70B-Chat-4bit");

    /// <summary>
    /// Developed by Yiwanju and Shenzhen Institute of Peking University for the legal industry, with further architectural upgrades based on the open source version, incorporating modules such as legal intention recognition, legal keyword extraction, and CoT inference enhancement, achieving performance improvements to meet legal Q&amp;A, legal statute retrieval, and other application needs.
    /// </summary>
    public static KnownModel ChatLaw { get; } = new("chatlaw", "ChatLaw");

    /// <summary>
    /// Developed by the Beijing Academy of AI, trained based on Aquila-7B, supporting fluent text dialogue and various language generation tasks, and through defining extensible special instruction specifications, realizing AquilaChat's call to other models and tools, and easy expansion.
    /// </summary>
    public static KnownModel AquilaChat_7B { get; } = new("aquilachat_7b", "AquilaChat-7B");
}