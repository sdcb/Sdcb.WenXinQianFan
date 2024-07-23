# Sdcb.WenXinQianFan [![NuGet](https://img.shields.io/nuget/v/Sdcb.WenXinQianFan.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Sdcb.WenXinQianFan/) [![NuGet](https://img.shields.io/nuget/dt/Sdcb.WenXinQianFan.svg?style=flat-square)](https://www.nuget.org/packages/Sdcb.WenXinQianFan/) [![GitHub](https://img.shields.io/github/license/sdcb/Sdcb.WenXinQianFan.svg?style=flat-square&label=license)](https://github.com/sdcb/Sdcb.WenXinQianFan/blob/master/LICENSE.txt)

**English** | **[简体中文](README.md)**

`Sdcb.WenXinQianFan` is an unofficial open-source project, providing a .NET client for the WenXin QianFan API. This project can be used to develop chatbots and virtual assistants capable of communicating with users in natural language.

## Features

- Provides .NET client for the WenXin QianFan API.
- Supports both synchronous and asynchronous communication.
- Implements the stream API for real-time communication.
- Provides a simple and intuitive API for chatbot development.

## Installation

`Sdcb.WenXinQianFan` can be installed via NuGet. Run the following command in the Package Manager Console to install the package:

```
Install-Package Sdcb.WenXinQianFan
```

## Usage

To use Sdcb.WenXinQianFan, you need to create a `QianFanClient` class instance. You can create the client by passing the WenXin QianFan API credentials to the constructor:

```csharp
QianFanClient client = new QianFanClient(apiKey, apiSecret);
```

### Example 1: Chatting with the virtual assistant using the synchronous API

The following example shows how to use the `ChatAsync` method to chat with a virtual assistant:

```csharp
QianFanClient c = new QianFanClient(apiKey, apiSecret);
ChatResponse msg = await c.ChatAsync(KnownModel.ERNIE_40_8K, new ChatMessage[]
{
    ChatMessage.FromUser("System prompt: Your name is Zhang San, a 5-year-old boy, you go to school at the Golden Cradle Kindergarten, your mother is Li Si, an engineer"),
    ChatMessage.FromAssistant("Understood"),
    ChatMessage.FromUser("Hello, little friend, I'm Teacher Zhou, where do you go to school?"),
});
Console.WriteLine(msg.Result);
```

### Example 2: Chatting with the virtual assistant using the stream API

The following example shows how to use the `ChatAsStreamAsync` method and the stream API to chat with a virtual assistant:

```csharp
StringBuilder sb = new StringBuilder();
QianFanClient c = new QianFanClient(apiKey, apiSecret);
await foreach (StreamedChatResponse msg in c.ChatAsStreamAsync(KnownModel.ERNIE_35_8K, new ChatMessage[] { ChatMessage.FromUser("Where is the capital of Hunan?") }, new ChatRequestParameters
{
    Temperature = 0.5f,
    PenaltyScore = 2.0f,
    UserId = "zhoujie"
}))
{
    sb.Append(msg.Result);
}
Console.WriteLine(sb.ToString());
```

## Supported Models

The following is a list of language models supported by Sdcb.WenXinQianFan:

| Model | Description |
| --- | --- |
| ERNIEBot | A large language model developed by Baidu that covers a vast amount of Chinese data and has strong abilities in dialogue question and answer, content creation and generation. |
| ERNIEBotTurbo | A large language model developed by Baidu that covers a vast amount of Chinese data and has strong abilities in dialogue question and answer, content creation and generation with a faster response speed. |
| ERNIE-Bot-4 | A large language model independently developed by Baidu, covering massive amounts of Chinese data. It has enhanced abilities in dialogue answering and content creation generation. |
| BLOOMZ_7B | A well-known large language model developed and open-sourced by BigScience that can output text in 46 languages and 13 programming languages. |
| Llama2_7bChat | Developed and open-sourced by Meta AI. It performs well in coding, reasoning, and knowledge application scenarios. Llama-2-7b-chat is a high-performance native open-source version suitable for dialogue scenarios. |
| Llama2_13bChat | Developed and open-sourced by Meta AI. It performs well in coding, reasoning, and knowledge application scenarios. Llama-2-13b-chat is a balanced native open-source version in terms of performance and results, suitable for dialogue scenarios. |
| Llama2_70bChat | Developed and open-sourced by Meta AI. It performs well in coding, reasoning, and knowledge application scenarios. Llama-2-70b-chat is a high-precision native open-source version. |
| QianfanBLOOMZ_7BCompressed | Qianfan team's compressed version based on BLOOMZ-7B, integrating quantization, sparsity and other technologies with memory usage reduced by more than 30%. |
| QianfanChineseLlama2_7B | Qianfan team's Chinese enhanced version based on Llama-2-7b, performing excellently on CMMLU, C-EVAL and other Chinese datasets. |
| ChatGLM2_6B_32K | The Chinese-English bilingual dialogue model released by Zhipu AI and Tsinghua KEG Laboratory, which can better handle up to 32K length of context. |
| AquilaChat_7B | Developed by Zhiyuan Research Institute, a dialogue model trained based on Aquila-7B, supports fluent text dialogue and multiple language type generation tasks. By defining extendable special command specifications, AquilaChat can call other models and tools, and is easy to extend. |

The latest list can be found [here on the official website](https://cloud.baidu.com/doc/WENXINWORKSHOP/s/Nlks5zkzu).

## License

Sdcb.WenXinQianFan is licensed under the MIT license. Please see the [LICENSE.txt](LICENSE.txt) file for more information.