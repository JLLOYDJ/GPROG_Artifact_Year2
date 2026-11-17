using System;
using UnityEngine;
[Serializable]
public class CoreTypeStats
{
    private PokemonTypes _type;

    // Using the method way of doing getters and setters as they are easier to make it clear as to how it works + allowing for extended flexibility in future.
    public PokemonTypes GetPokemonType()
    {
        return _type;
    }

    public void SetPokemonType(PokemonTypes newType)
    {
        _type = newType;
    }
}
