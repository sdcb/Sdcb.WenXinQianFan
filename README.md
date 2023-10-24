# Sdcb.WenXinQianFan [![NuGet](https://img.shields.io/nuget/v/Sdcb.WenXinQianFan.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Sdcb.WenXinQianFan/) [![NuGet](https://img.shields.io/nuget/dt/Sdcb.WenXinQianFan.svg?style=flat-square)](https://www.nuget.org/packages/Sdcb.WenXinQianFan/) [![GitHub](https://img.shields.io/github/license/sdcb/Sdcb.WenXinQianFan.svg?style=flat-square&label=license)](https://github.com/sdcb/Sdcb.WenXinQianFan/blob/master/LICENSE.txt)

**[English](README_EN.md)** | **简体中文**

`Sdcb.WenXinQianFan`是一个非官方的开源项目，提供WenXin QianFan API 的 .NET 客户端。这个项目可以用来开发能够用自然语言与用户交流的聊天机器人和虚拟助手。

## 功能

- 为 WenXin QianFan API 提供 .NET 客户端。
- 支持同步和异步通信。
- 实现了流API，以实现实时通信。
- 为聊天机器人开发提供了简单直观的API。

## 安装

通过NuGet可以安装 `Sdcb.WenXinQianFan`。 在程序包管理器控制台中运行以下命令以安装软件包：

```
Install-Package Sdcb.WenXinQianFan
```

## 使用方法

要使用 Sdcb.WenXinQianFan，您需要创建一个 `QianFanClient` 类实例。您可以通过将WenXin QianFan API凭据传递给构造函数来创建客户端：

```csharp
QianFanClient client = new QianFanClient(apiKey, apiSecret);
```

### 示例1：使用同步API与虚拟助手聊天

以下示例显示了如何使用 `ChatAsync` 方法与虚拟助手聊天：

```csharp
QianFanClient c = new QianFanClient(apiKey, apiSecret);
ChatResponse msg = await c.ChatAsync(KnownModel.ERNIEBotTurbo, new ChatMessage[]
{
    ChatMessage.FromUser("系统提示：你叫张三，一名5岁男孩，你在金色摇篮幼儿园上学，你的妈妈叫李四，是一名工程师"),
    ChatMessage.FromAssistant("明白"),
    ChatMessage.FromUser("你好小朋友，我是周老师，你在哪上学？"),
});
Console.WriteLine(msg.Result);
```

### 示例2：使用流API与虚拟助手聊天

以下示例显示了如何使用 `ChatAsStreamAsync` 方法以及流API与虚拟助手聊天：

```csharp
StringBuilder sb = new StringBuilder();
QianFanClient c = new QianFanClient(apiKey, apiSecret);
await foreach (StreamedChatResponse msg in c.ChatAsStreamAsync(KnownModel.ERNIEBot, new ChatMessage[] { ChatMessage.FromUser("湖南的省会在哪？") }, new ChatRequestParameters
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

## 支持的模型

以下是 Sdcb.WenXinQianFan 支持的语言模型列表：

| 模型 | 描述 |
| --- | --- |
| ERNIEBot | 百度自行研发的大语言模型，覆盖海量中文数据，具有更强的对话问答、内容创作生成等能力。 |
| ERNIEBotTurbo | 百度自行研发的大语言模型，覆盖海量中文数据，具有更强的对话问答、内容创作生成等能力，响应速度更快。 |
| BLOOMZ_7B | 业内知名的大语言模型，由BigScience研发并开源，能够以46种语言和13种编程语言输出文本。 |
| Llama2_7bChat | Meta AI研发并开源，在编码、推理及知识应用等场景表现优秀，Llama-2-7b-chat是高性能原生开源版本，适用于对话场景。 |
| Llama2_13bChat | Meta AI研发并开源，在编码、推理及知识应用等场景表现优秀，Llama-2-13b-chat是性能与效果均衡的原生开源版本，适用于对话场景。 |
| Llama2_70bChat | Meta AI研发并开源，在编码、推理及知识应用等场景表现优秀，Llama-2-70b-chat是高精度效果的原生开源版本。 |
| QianfanBLOOMZ_7BCompressed | 千帆团队在BLOOMZ-7B基础上的压缩版本，融合量化、稀疏化等技术，显存占用降低30%以上。 |
| QianfanChineseLlama2_7B | 千帆团队在Llama-2-7b基础上的中文增强版本，在CMMLU、C-EVAL等中文数据集上表现优异。 |
| ChatGLM2_6B_32K | 智谱AI与清华KEG实验室发布的中英双语对话模型，能够更好的处理最多32K长度的上下文。 |
| AquilaChat_7B | 由智源研究院研发，基于Aquila-7B训练的对话模型，支持流畅的文本对话及多种语言类生成任务，通过定义可扩展的特殊指令规范，实现 AquilaChat对其它模型和工具的调用，且易于扩展。 |

最新的列表可以在[官网这里](https://cloud.baidu.com/doc/WENXINWORKSHOP/s/Nlks5zkzu)了解。

## 许可证

Sdcb.WenXinQianFan 遵循 MIT 许可证。 请参阅[LICENSE.txt](LICENSE.txt)文件以获取更多信息。