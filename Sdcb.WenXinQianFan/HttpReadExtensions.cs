using System.IO;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Sdcb.WenXinQianFan;

internal static class HttpReadExtensions
{
    public static async Task<string> C_ReadAsStringAsync(this System.Net.Http.HttpContent content, CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_0
        return await content.ReadAsStringAsync();
#else
        return await content.ReadAsStringAsync(cancellationToken);
#endif
    }

    public static async Task<Stream> C_ReadAsStreamAsync(this System.Net.Http.HttpContent content, CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_0
        return await content.ReadAsStreamAsync();
#else
        return await content.ReadAsStreamAsync(cancellationToken);
#endif
    }

    public static async Task<T?> C_ReadFromJsonAsync<T>(this System.Net.Http.HttpContent content, CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_0
        return await content.ReadFromJsonAsync<T>();
#else
        return await content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);
#endif
    }
}
