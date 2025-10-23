using KwikNesta.Contracts.Models;
using System.Net;
using System.Text;
using System.Text.Json;

namespace KwikNesta.Contracts.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T?> ReadFromJsonAsync<T>(this HttpResponseMessage response,
                                                          JsonSerializerOptions? options = null)
        {
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(stream, options ?? new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public static HttpResponseMessage CreateSyntheticResponse(this HttpStatusCode statusCode, string message)
        {
            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(
                    JsonSerializer.Serialize(new ApiResult<object?>
                    {
                        Successful = false,
                        Message = message,
                        Status = (int)statusCode,
                        Data = (object?)null
                    }),
                    Encoding.UTF8,
                    "application/json")
            };
            return response;
        }
    }
}
