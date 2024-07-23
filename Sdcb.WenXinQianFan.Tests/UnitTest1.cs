using Microsoft.Extensions.Configuration;
using System.Text;
using Xunit.Abstractions;

namespace Sdcb.WenXinQianFan.Tests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _console;

        static UnitTest1()
        {
            Config = new ConfigurationBuilder()
                .AddUserSecrets<UnitTest1>()
                .Build();
        }

        public static IConfigurationRoot Config { get; }

        static QianFanClient CreateAPIClient()
        {
            string? apiKey = Config["QianFanConfig:ApiKey"];
            string? apiSecret = Config["QianFanConfig:ApiSecret"];
#pragma warning disable CS8604 // 引用类型参数可能为 null。
            return new QianFanClient(apiKey, apiSecret);
#pragma warning restore CS8604 // 引用类型参数可能为 null。
        }

        public UnitTest1(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public async Task ChatAsStreamAsyncTest()
        {
            StringBuilder sb = new();
            QianFanClient c = CreateAPIClient();
            await foreach (StreamedChatResponse msg in c.ChatAsStreamAsync(KnownModel.ERNIEBot, new ChatMessage[] { ChatMessage.FromUser("湖南的省会在哪？") }, new ChatRequestParameters
            {
                Temperature = 0.5f,
                UserId = "zhoujie",
                DisableSearch = true,
            }))
            {
                // append the result to the string builder
                sb.Append(msg.Result);
            }

            Assert.Contains("长沙", sb.ToString());
            _console.WriteLine(sb.ToString());
        }

        [Fact]
        public async Task SystemPromptTest()
        {
            QianFanClient c = CreateAPIClient();
            ChatResponse msg = await c.ChatAsync(KnownModel.ERNIEBotTurbo, new ChatMessage[]
            {
                ChatMessage.FromUser("你好小朋友，我是周老师，你在哪上学？"),
            }, new ChatRequestParameters()
            {
                System = "你叫张三，一名5岁男孩，你在金色摇篮幼儿园上学，你的妈妈叫李四，是一名工程师",
                DisableSearch = true, 
            });
            _console.WriteLine(msg.Result);
            Assert.Contains("金色摇篮幼儿园", msg.Result);
        }

        [Fact]
        public async Task ChatSearchTest()
        {
            QianFanClient c = CreateAPIClient();
            ChatResponse msg = await c.ChatAsync(KnownModel.ERNIEBot, new ChatMessage[]
            {
                ChatMessage.FromUser(".NET最新版本号是多少？最新版有哪些新功能？"),
            }, new ChatRequestParameters
            {
                EnableCitation = true,
                DisableSearch = false
            });
            _console.WriteLine(msg.Result);
            Assert.NotNull(msg.SearchInfo);
            Assert.NotNull(msg.RateLimitInfo);

            _console.WriteLine("Search Results:");
            foreach (SearchResult item in msg.SearchInfo!.SearchResults)
            {
                _console.WriteLine(item.Title + "(" + item.Url + ")");
            }
        }
    }
}