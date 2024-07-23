using System;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Sdcb.WenXinQianFan;

internal class UnixDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // 把读取到的数字作为Unix时间戳并转换为DateTimeOffset
        var unixTime = reader.GetInt64();
        return DateTimeOffset.FromUnixTimeSeconds(unixTime);
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        // 把DateTimeOffset转换为Unix时间戳
        var unixTime = value.ToUnixTimeSeconds();
        writer.WriteNumberValue(unixTime);
    }
}