using PokedexApi.NET.Models;
using PokedexApi.NET.Utils;
using PokedexApi.NET.Utils.Factory;

namespace PokedexApi.NET.Clients;

internal class MoveService : IResourceService<Move, Move>
{
    private readonly HttpClientManager _client = HttpClientManager.Instance;
    public async Task<List<Move>?> GetResourceList(ResourceListRequest? request = null)
    {
        request ??= ResourceListFactory.Create(ResourceListType.Moves);
        if (request is not TypesListRequest)
            throw new ArgumentException("The request has to be a TypesListRequest");
        var response = await _client.SendPostRequest<List<Move>>("/moves/getMovesList", request);
        return response;
    }

    public async Task<Move?> GetResourceByName(string name)
    {
        var response = await _client.SendGetRequest<Move>($"/moves/getByName/{name}");
        return response;
    }
}