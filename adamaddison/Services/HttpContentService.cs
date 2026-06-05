using System;
using System.Text.Json;
using adamaddison.Interfaces;

namespace adamaddison.Services;

public class HttpContentService<T> : IHttpContentService<T>
{
    private readonly HttpClient _http;
    private readonly ILogger<HttpContentService<T>> _logger;

    public HttpContentService(HttpClient http, ILogger<HttpContentService<T>> logger)
    {
        _http = http;
        _logger = logger;
    }

    public async Task<T> GetContentFromUrlAsync(string Url)
    {
        T viewModel;
        try
        {
            var content = await _http.GetStringAsync(Url);

            viewModel = JsonSerializer.Deserialize<T>(content) ?? throw new InvalidOperationException("Failed to deserialise remote content.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve remote content.");
            throw new InvalidOperationException("Failed to retrieve remote content.");
        }
        
        return viewModel;
    }
}
