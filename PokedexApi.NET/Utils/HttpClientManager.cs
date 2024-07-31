using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using PokedexApi.NET.Models;

namespace PokedexApi.NET.Utils;

internal class HttpClientManager : IDisposable
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;
    private static HttpClientManager? _instance;

    private HttpClientManager(string baseAddress)
    {
        _client = new HttpClient { BaseAddress = new Uri(baseAddress) };
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public static HttpClientManager Instance =>
        _instance ??= new HttpClientManager("https://pokedex.cristianoaloigi.it");

    public async Task<T?> SendGetRequest<T>(string endpoint)
    {
        try
        {
            var response = await _client.GetFromJsonAsync<T>(endpoint, _options);
            return response;
        }
        catch (Exception)
        {
            return default;
        }
    }

    public async Task<T?> SendPostRequest<T>(string endpoint, object data)
    {
        try
        {
            var jsonBody = JsonSerializer.Serialize(data, _options);
            var bodyContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(endpoint, bodyContent);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<T>(content, _options);
            return result;
        }
        catch (Exception)
        {
            return default;
        }
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}