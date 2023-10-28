using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApi.NET.Utils.Factory
{
    internal class ResourceListFactory
    {
        public static ResourceListRequest Create(ResourceListType type)
        {
            return type switch
            {
                ResourceListType.Moves => new MoveListRequest
                {
                    Limit = 100,
                    MoveCategory = "",
                    Name = "",
                    Offset = 0,
                    OnlyMt = false,
                    Types = new List<string>()
                },
                ResourceListType.Types => new TypesListRequest
                {
                    Limit = 100, Types = new List<string>(), Name = "", Offset = 0,
                },
                ResourceListType.Resource => new ResourceListRequest { Limit = 100, Name = "", Offset = 0, },
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }

    internal enum ResourceListType
    {
        Resource,
        Types,
        Moves
    }
}
