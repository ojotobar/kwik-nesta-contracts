using KwikNesta.Contracts.Extensions;
using KwikNesta.Contracts.Models;
using System.Net;
using System.Text;
using System.Text.Json;

namespace KwikNesta.Contracts.Http
{
    public class ServiceRefitWakeUpHandler : DelegatingHandler
    {
        private readonly int _maxRetries;
        private readonly int _delayMs;

        public ServiceRefitWakeUpHandler(int maxRetries = 5, int delayMs = 10000)
        {
            _maxRetries = maxRetries;
            _delayMs = delayMs;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            for (int attempt = 1; attempt <= _maxRetries; attempt++)
            {
                var response = await base.SendAsync(request, cancellationToken);

                // Check if the response is JSON
                if (await IsJson(response))
                    return response;

                string body = await response.Content.ReadAsStringAsync();

                // Render waking up?
                if (body.Contains("Render", StringComparison.OrdinalIgnoreCase) ||
                    body.Contains("waking", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"⚠️ Render wake-up detected (attempt {attempt}) — retrying in {_delayMs}ms...");
                    await Task.Delay(_delayMs, cancellationToken);
                    continue;
                }

                return HttpStatusCode.ServiceUnavailable
                    .CreateSyntheticResponse("Server not ready or returned invalid JSON.");
            }

            return HttpStatusCode.ServiceUnavailable
                    .CreateSyntheticResponse("Render service still waking up. Please try again later.");
        }

        private static async Task<bool> IsJson(HttpResponseMessage response)
        {
            if (response.Content.Headers.ContentType?.MediaType == "application/json")
            {
                string content = await response.Content.ReadAsStringAsync();
                return content.TrimStart().StartsWith("{") || content.TrimStart().StartsWith("[");
            }
            return false;
        }
    }
}