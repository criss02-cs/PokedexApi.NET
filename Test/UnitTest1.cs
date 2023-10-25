using PokedexApi.NET.Utils;
using Type = PokedexApi.NET.Models.Type;

namespace Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestTypeEqual()
    {
        Assert.AreNotEqual(Type.Elettro, Type.Normale);
        Assert.False(Type.Elettro == Type.Acqua);
    }

    [Test]
    public async Task TestPokemonList()
    {
        using var client = new PokeClient();
        var results = await client.GetPokemonList();
        Assert.IsTrue(results.Count == 100);
        var filter = new TypesListRequest
        {
            Limit = 50,
            Name = "chu",
            Offset = 0,
            Types = new List<string>() { Type.Elettro.Id }
        };
        results = await client.GetPokemonList(filter);
        Assert.IsTrue(results.Count < 50);
        Assert.IsTrue(results.Exists(x => x.Name == "Pikachu"));
        Assert.IsTrue(results.Count == 3);
    }

    [Test]
    public async Task TestPokemonResource()
    {
        using var client = new PokeClient();
        var result = await client.GetPokemonByName("bulbasaur");
        Assert.IsTrue(result?.Name == "Bulbasaur");
    }

    [Test]
    public async Task TestAbility()
    {
        using var client = new PokeClient();
        var result = await client.GetAbilityByName("tanfo");
        Assert.IsTrue(result.Name == "Tanfo");
        var filter = new TypesListRequest
        {
            Limit = 50,
            Name = "ab",
            Offset = 0,
        };
        var list = await client.GetAbilityList(filter);
        Assert.IsTrue(list is { Count: 50 });
    }
    
    [Test]
    public async Task TestMove()
    {
        using var client = new PokeClient();
        var result = await client.GetMoveByName("abbagliante");
        Assert.IsTrue(result.Name == "Abbagliante");
        var filter = new MoveListRequest
        {
            Limit = 50,
            Name = "dra",
            Offset = 0,
            Types = new List<string>
            {
                Type.Drago.Id
            }
        };
        var list = await client.GetMovesList(filter);
        Assert.IsTrue(list.Count < 50);
    }
}