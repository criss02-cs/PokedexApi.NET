using System.Net.Http.Json;
using System.Text.Json;
using PokedexApi.NET.Clients;
using PokedexApi.NET.Models;
using PokedexApi.NET.Utils;

namespace PokedexApi.NET;

public class PokeClient : IDisposable
{
    private readonly PokemonService _pokemonService = new();
    private readonly AbilityService _abilityService = new();
    private readonly MoveService _moveService = new();
    public async Task<List<PokemonList>?> GetPokemonList(TypesListRequest? request = null)
    {
        return await _pokemonService.GetResourceList(request);
    }

    public async Task<PokemonResource?> GetPokemonByName(string name)
    {
        return await _pokemonService.GetResourceByName(name);
    }
    public async Task<List<Ability>?> GetAbilityList(ResourceListRequest? request = null)
    {
        return await _abilityService.GetResourceList(request);
    }
    public async Task<Ability?> GetAbilityByName(string name)
    {
        return await _abilityService.GetResourceByName(name);
    }
    public async Task<List<Move>?> GetMovesList(MoveListRequest? request = null)
    {
        return await _moveService.GetResourceList(request);
    }
    public async Task<Move?> GetMoveByName(string name)
    {
        return await _moveService.GetResourceByName(name);
    }
    public void Dispose()
    {
        HttpClientManager.Instance.Dispose();
        GC.SuppressFinalize(this);
    }
}