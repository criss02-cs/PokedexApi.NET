using System.Net.Http.Json;
using System.Text.Json;

namespace PokedexApi.NET.Utils;

internal class HttpClientManager : IDisposable
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;
    private static HttpClientManager? _instance;
    
    private HttpClientManager(string baseAddress)
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri(baseAddress);
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public static HttpClientManager Instance => 
        _instance ??= new HttpClientManager("https://crissscode-pokedex-api.cyclic.app");

    public async Task<T?> SendGetRequest<T>(string endpoint)
    {
        var response = await _client.GetFromJsonAsync<T>(endpoint, _options);
        return response;
    }
    
    public async Task<T?> SendPostRequest<T>(string endpoint, object data)
    {
        var response = await _client.PostAsJsonAsync(endpoint, data, _options);
        var result = await response.Content.ReadFromJsonAsync<T>(_options);
        return result;
    }
    
    public void Dispose()
    {
        _client.Dispose();
    }
}