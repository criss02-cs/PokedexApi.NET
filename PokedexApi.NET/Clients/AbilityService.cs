using PokedexApi.NET.Models;
using PokedexApi.NET.Utils;
using PokedexApi.NET.Utils.Factory;

namespace PokedexApi.NET.Clients;

internal class AbilityService : IResourceService<Ability, Ability>
{
    private readonly HttpClientManager _client = HttpClientManager.Instance;
    public async Task<List<Ability>?> GetResourceList(ResourceListRequest? request = null)
    {
        request ??= ResourceListFactory.Create(ResourceListType.Resource);
        var response = await _client.SendPostRequest<List<Ability>>("/abilita/getPokemonList", request);
        return response;
    }

    public async Task<Ability?> GetResourceByName(string name)
    {
        var response = await _client.SendGetRequest<Ability>($"abilita/getByName/{name}");
        return response;
    }

    public async Task<List<Ability>?> GetListById(List<string> ids)
    {
        if (!ids.Any())
        {
            throw new ArgumentException("La lista degli id non può essere vuota");
        }
        var response = await _client.SendPostRequest<List<Ability>>("/abilita/getAbilityListById", ids);
        return response;
    }
}