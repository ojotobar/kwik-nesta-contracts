using KwikNesta.Contracts.Extensions;
using KwikNesta.Contracts.Models;
using System.Net;
using System.Text;
using System.Text.Json;

namespace KwikNesta.Contracts.Http
{
    public class ServiceHttpClientWakeUpHandler : DelegatingHandler
    {
        private readonly int _maxRetries;
        private readonly int _delayMs;

        public ServiceHttpClientWakeUpHandler(HttpMessageHandler innerHandler = null!,
                                              int maxRetries = 5,
                                              int delayMs = 10000)
            : base(innerHandler ?? new HttpClientHandler())
        {
            _maxRetries = maxRetries;
            _delayMs = delayMs;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken)
        {
            for (int attempt = 1; attempt <= _maxRetries; attempt++)
            {
                var response = await base.SendAsync(request, cancellationToken);

                if (await IsValidJsonResponse(response))
                    return response;

                // Non-JSON response — possibly Render's waking-up page
                string body = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"⚠️ Render wake-up detected on attempt {attempt}: {body[..Math.Min(100, body.Length)]}...");

                if (attempt < _maxRetries)
                {
                    await Task.Delay(_delayMs, cancellationToken);
                    continue;
                }

                return HttpStatusCode.ServiceUnavailable
                    .CreateSyntheticResponse("Server is waking up, please retry shortly.");
            }

            return HttpStatusCode.ServiceUnavailable
                .CreateSyntheticResponse("Unexpected state reached in RenderWakeUpHandler");
        }

        private static async Task<bool> IsValidJsonResponse(HttpResponseMessage response)
        {
            var contentType = response.Content.Headers.ContentType?.MediaType;
            if (contentType != "application/json")
                return false;

            string text = await response.Content.ReadAsStringAsync();
            return text.TrimStart().StartsWith("{") || text.TrimStart().StartsWith("[");
        }
    }
}