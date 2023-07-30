using System.Text.Json;

namespace EventManagment.Infrastructure.Gateway.Extensions;
public static class HttpClientExtensions
{
    public static async Task<T> ReadContentAs<T>(this HttpResponseMessage responseMessage)
    {
        string readAsString = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

        return JsonSerializer.Deserialize<T>(readAsString,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}
