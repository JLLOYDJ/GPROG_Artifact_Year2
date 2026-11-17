using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class TypeDefences
{
    private List<PokemonTypes> _weaknesses = new List<PokemonTypes>();
    private List<PokemonTypes> _resistences = new List<PokemonTypes>();
    private List<PokemonTypes> _immunities = new List<PokemonTypes>();
    public List<PokemonTypes> GetWeaknesses()
    {
        return _weaknesses;
    }
    public List<PokemonTypes> GetResistences()
    {
        return _resistences;
    }
    public List<PokemonTypes> GetImmunities()
    {
        return _immunities;
    }
    public void AddWeakness(PokemonTypes typeWeakness)
    {
        _weaknesses.Add(typeWeakness);
    }
    public void AddResistence(PokemonTypes typeResistence)
    {
        _resistences.Add(typeResistence);
    }
    public void AddImmunities(PokemonTypes typeImmunity)
    {
        _immunities.Add(typeImmunity);
    }
    public void RemoveWeakness(PokemonTypes typeWeakness)
    {
        _weaknesses.Remove(typeWeakness);
    }
    public void RemoveResistence(PokemonTypes typeResistence)
    {
        _resistences.Remove(typeResistence);
    }
    public void RemoveImmunities(PokemonTypes typeImmunities)
    {
        _immunities.Remove(typeImmunities);
    }
}
