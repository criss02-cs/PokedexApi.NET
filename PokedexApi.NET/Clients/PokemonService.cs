using PokedexApi.NET.Models;
using PokedexApi.NET.Utils;

namespace PokedexApi.NET.Clients;

internal class PokemonService : IResourceService<PokemonList, PokemonResource>
{
    private readonly HttpClientManager _client = HttpClientManager.Instance;
    public async Task<List<PokemonList>?> GetResourceList(ResourceListRequest? request = null)
    {
        request ??= new TypesListRequest
        {
            Limit = 100,
            Offset = 0,
            Name = string.Empty,
            Types = new List<string>()
        };
        if (request is not TypesListRequest)
            throw new ArgumentException("The request has to be a TypesListRequest");
        var response = await _client.SendPostRequest<List<PokemonList>>("/pokemon/getPokemonList", request);
        return response;
    }

    public async Task<PokemonResource?> GetResourceByName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("The name cannot be null or empty");
        var response = await _client.SendGetRequest<PokemonResource>($"/pokemon/getByName/{name}");
        return response;
    }
}