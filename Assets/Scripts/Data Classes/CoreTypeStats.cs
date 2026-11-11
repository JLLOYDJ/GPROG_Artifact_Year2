using UnityEngine;

public class CoreTypeStats
{
    private byte _type;

    // Using the method way of doing getters and setters as they are easier to make it clear as to how it works + allowing for extended flexibility in future.
    public byte GetPokemonType()
    {
        return _type;
    }

    public void SetPokemonType(byte newType)
    {
        _type = newType;
    }
}
