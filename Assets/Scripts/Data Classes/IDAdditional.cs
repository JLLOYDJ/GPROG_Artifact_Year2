using System;
using UnityEngine;
[Serializable]
public class IDAdditional
{
    private monsterSize _size;
    private bool _isMale;
    private string _nativeRegion;
    private float _sr;
    public monsterSize GetCurrentSize()
    {
        return _size;
    }
    public void SetCurrentSize(monsterSize newSize)
    {
        _size = newSize;
    }
    public bool GetCurrentGender()
    {
        return _isMale;
    }
    /// <summary>
    /// Gender goes off the bool "isMale". If true, the pokemon is Male, if false, the pokemon is female.
    /// </summary>
    /// <param name="newGender"></param>
    public void SetCurrentGender(bool isMale)
    {
        _isMale = isMale;
    }
    public string GetCurrentNativeRegion()
    {
        return _nativeRegion;
    }
    public void SetCurrentNativeRegion(string newRegion)
    {
        _nativeRegion = newRegion;
    }
    public float GetCurrentSR()
    {
        return _sr;
    }
    public void SetCurrentSR(float newSR)
    {
        _sr = newSR;
    }
}
