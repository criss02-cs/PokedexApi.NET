using PokedexApi.NET.Models;
using PokedexApi.NET.Utils;

namespace PokedexApi.NET.Clients;

internal interface IResourceService<TResourceList, TResource> 
    where TResource : Resource
    where TResourceList : Resource
{
    Task<List<TResourceList>?> GetResourceList(ResourceListRequest? request = null);
    Task<TResource?> GetResourceByName(string name);
}