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
    public PP powerPoints = new PP();

    private byte _movePower = Convert.ToByte(movePower.none);
    public byte GetMovePower()
    {
        return _movePower;
    }
    public void SetMovePower(byte newMovePower)
    {
        _movePower = newMovePower;
    }

    // Methods from Interfaces
    public abstract void Activate(BasePokemon User);
    public bool PPCheck()
    {
        if (powerPoints.GetPPCurrent() == 0)
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
