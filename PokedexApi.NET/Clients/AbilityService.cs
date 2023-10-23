using PokedexApi.NET.Models;
using PokedexApi.NET.Utils;

namespace PokedexApi.NET.Clients;

internal class AbilityService : IResourceService<Ability, Ability>
{
    private readonly HttpClientManager _client = HttpClientManager.Instance;
    public async Task<List<Ability>?> GetResourceList(ResourceListRequest? request = null)
    {
        request ??= new ResourceListRequest
        {
            Limit = 100,
            Offset = 0,
            Name = string.Empty,
        };
        var response = await _client.SendPostRequest<List<Ability>>("/abilita/getPokemonList", request);
        return response;
    }

    public async Task<Ability?> GetResourceByName(string name)
    {
        var response = await _client.SendGetRequest<Ability>($"abilita/getByName/{name}");
        return response;
    }
}