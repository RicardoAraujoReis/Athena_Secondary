using Common.Wrapper;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Athena.Web.Extensions;

internal static class ResponseExtensions
{
    internal static async Task<ResponseWrapper<T>> ToResponse<T>(this HttpResponseMessage message)
    {
        var responseAsString = await message.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<ResponseWrapper<T>>(responseAsString, 
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            });

        return response;
    }
}