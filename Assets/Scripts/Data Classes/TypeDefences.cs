using System;
using System.Collections.Generic;
using UnityEngine;

public class TypeDefences
{
    private List<Byte> _weaknesses = new List<Byte>();
    private List<Byte> _resistences = new List<Byte>();
    private List<Byte> _immunities = new List<Byte>();
    public List<Byte> GetWeaknesses()
    {
        return _weaknesses;
    }
    public List<Byte> GetResistences()
    {
        return _resistences;
    }
    public List<Byte> GetImmunities()
    {
        return _immunities;
    }
    public void AddWeakness(byte typeWeakness)
    {
        _weaknesses.Add(typeWeakness);
    }
    public void AddResistence(byte typeResistence)
    {
        _resistences.Add(typeResistence);
    }
    public void AddImmunities(byte typeImmunity)
    {
        _immunities.Add(typeImmunity);
    }
    public void RemoveWeakness(byte typeWeakness)
    {
        _weaknesses.Remove(typeWeakness);
    }
    public void RemoveResistence(byte typeResistence)
    {
        _resistences.Remove(typeResistence);
    }
    public void RemoveImmunities(byte typeImmunities)
    {
        _immunities.Remove(typeImmunities);
    }
}
