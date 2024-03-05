using System.Text;

namespace TravelAggregator.Service.Services;

public class HttpInteractionService
{
    private readonly ILogger<HttpInteractionService> _logger;
    private readonly IHttpClientFactory _httpClient;

    public HttpInteractionService(ILogger<HttpInteractionService> logger, IHttpClientFactory httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    /// <summary>
    /// Sends request by http protocol
    /// </summary>
    /// <param name="uri">Endpoint location</param>
    /// <param name="method">Endpoint method</param>
    /// <param name="service">Service title that invokes request</param>
    /// <param name="body">Body to be sent</param>
    /// <param name="mediaType">Media type of the request</param>
    /// <param name="headers">Request headers</param>
    /// <returns>string content of response</returns>
    public async Task<string> SendRequest(string uri, HttpMethod method, string service, string? body = null, string? mediaType = null, Dictionary<string, string> headers = null)
    {
        var request = new HttpRequestMessage(method, uri);

        if (body != null && method != HttpMethod.Get)
        {
            request.Content = new StringContent(body, Encoding.UTF8, mediaType ?? "application/json");
        }

        if (headers != null)
        {
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }

        var client = _httpClient.CreateClient();

        var response = await client.SendAsync(request);
        _logger.LogDebug("{} response {}", service, response);

        var responseContent = await response.Content.ReadAsStringAsync();
        _logger.LogDebug("{} response content {}", service, responseContent);

        return responseContent;
    }
}
