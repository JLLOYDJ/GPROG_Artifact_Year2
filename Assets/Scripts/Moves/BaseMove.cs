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
    private movePower _movePower = movePower.none;
    public movePower GetMovePower()
    {
        return _movePower;
    }
    public void SetMovePower(movePower newMovePower)
    {
        _movePower = newMovePower;
    }
    private moveVariant _moveVariant;
    public moveVariant GetMoveVariant()
    {
        return _moveVariant;
    }
    public void SetMoveVariant(moveVariant newVariant)
    {
        _moveVariant = newVariant;
    }

    // Methods from Interfaces
    public abstract void Activate(BasePokemon User);
    public bool PPCheck()
    {
        if (powerPoints.GetPPCurrent() == 0)
        {
            GameManager.GameInstance.PPFail();
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool MoveTime(bool IsAction)
    {
        // This checks the manager to see what action and bonus action is left. 
        // If it has the corrolating action/bonus available, it passes through true, it not, it passes false and doesn't continue the move.
        return false; // Temp, remove when actual code is here.
    }
}
