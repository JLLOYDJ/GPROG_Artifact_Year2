using System;
using UnityEngine;

public abstract class BaseMove : IAction, IMove
{
    // Reusable Data Classes
    // (Originally had protected, but due to their getters and setters, they need to be public to be accessed)
    public ID moveID = new ID();
    public CoreActionStats coreStats = new CoreActionStats();
    public CoreTypeStats coreType = new CoreTypeStats();
    public Level levelStats = new Level();

    // Data Specific to Moves
    private byte _ppCurrent = 0;
    private byte _ppMax = 0;
    private byte _movePower = Convert.ToByte(movePower.none);

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
    public byte GetMovePower()
    {
        return _movePower;
    }
    public void SetMovePower(byte newMovePower)
    {
        _movePower = newMovePower;
    }

    // Methods from Interfaces
    public abstract void Activate();
    public bool PPCheck(byte PPcurrent)
    {
        if (PPcurrent == 0)
        {
            PPFail();
            return false;
            
        }
        else
        {
            return true;
        }
    }
    public void PPFail()
    {
        // Due to not having the rest of the code yet, this will have a debug log.
        // The goal will to go to the manager, and ask it to check if the other moves have PP left, if not, it would trigger stuggle.
        Debug.Log("Calling Manager to check if any PP is left");
    }

    public bool MoveTime(bool IsAction)
    {
        // This checks the manager to see what action and bonus action is left. 
        // If it has the corrolating action/bonus available, it passes through true, it not, it passes false and doesn't continue the move.
        return false; // Temp, remove when actual code is here.
    }
}
