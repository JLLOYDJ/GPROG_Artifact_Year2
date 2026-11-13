using System;
using UnityEngine;

public class PP
{
    private byte _ppCurrent = 0;
    private byte _ppMax = 0;

    // Getter/Setters
    public byte GetPPCurrent()
    {
        return _ppCurrent;
    }

    public void SetPPCurrent(byte newPPCurrent)
    {
        _ppCurrent = newPPCurrent;
    }
    public void ReducePPCurrent()
    {
        _ppCurrent--;
    }
    public byte GetPPMax()
    {
        return _ppMax;
    }
    public void SetPPMax(byte newPPMax)
    {
        _ppMax = newPPMax;
    }
}
