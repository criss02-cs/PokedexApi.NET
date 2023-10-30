using PokedexApi.NET.Models;
using PokedexApi.NET.Utils;
using PokedexApi.NET.Utils.Factory;

namespace PokedexApi.NET.Clients;

internal class PokemonService : IResourceService<PokemonList, PokemonResource>
{
    private readonly HttpClientManager _client = HttpClientManager.Instance;
    public async Task<List<PokemonList>?> GetResourceList(ResourceListRequest? request = null)
    {
        request ??= ResourceListFactory.Create(ResourceListType.Types);
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

    public async Task<PokemonResource?> GetByPokedexId(int pokedexId)
    {
        if (pokedexId <= 0)
            throw new ArgumentException("The pokedex id cannot be 0 or less");
        var response = await _client.SendGetRequest<PokemonResource>($"/pokemon/getByPokedexId/{pokedexId}");
        return response;
    }
}