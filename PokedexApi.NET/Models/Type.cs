using System.Text.Json.Serialization;

namespace PokedexApi.NET.Models;

public class Type : IEquatable<Type>
{
    [JsonPropertyName("_id")] public string Id { get; }

    public Type(string id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((Type)obj);
    }
    public bool Equals(Type? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    
    public static bool operator ==(Type obj1, Type obj2)
    {
        if (ReferenceEquals(obj1, obj2)) 
            return true;
        if (ReferenceEquals(obj1, null)) 
            return false;
        return !ReferenceEquals(obj2, null) && obj1.Equals(obj2);
    }
    public static bool operator !=(Type obj1, Type obj2) => !(obj1 == obj2);

    public static Type Normale => new Type("652d03ffec594fc5b8a0248a");
    public static Type Lotta => new Type("652d0400ec594fc5b8a0248b");
    public static Type Volante => new Type("652d0400ec594fc5b8a0248c");
    public static Type Veleno => new Type("652d0400ec594fc5b8a0248d");
    public static Type Terra => new Type("652d0401ec594fc5b8a0248e");
    public static Type Roccia => new Type("652d0401ec594fc5b8a0248f");
    public static Type Coleottero => new Type("652d0401ec594fc5b8a02490");
    public static Type Spettro => new Type("652d0401ec594fc5b8a02491");
    public static Type Acciaio => new Type("652d0402ec594fc5b8a02492");
    public static Type Fuoco => new Type("652d0402ec594fc5b8a02493");
    public static Type Acqua => new Type("652d0402ec594fc5b8a02494");
    public static Type Erba => new Type("652d0402ec594fc5b8a02495");
    public static Type Elettro => new Type("652d0402ec594fc5b8a02496");
    public static Type Psico => new Type("652d0402ec594fc5b8a02497");
    public static Type Ghiaccio => new Type("652d0403ec594fc5b8a02498");
    public static Type Drago => new Type("652d0403ec594fc5b8a02499");
    public static Type Buio => new Type("652d0403ec594fc5b8a0249a");
    public static Type Folletto => new Type("652d0404ec594fc5b8a0249b");
}
