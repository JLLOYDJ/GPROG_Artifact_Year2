using NUnit.Framework.Internal.Filters;
using System;
using UnityEngine;
[Serializable]
public class CoreMoves
{
    private static byte _amountOfCurrentMoves = 5; // Forgot to set it.
    private BaseMove[] _currentMoves = new BaseMove[_amountOfCurrentMoves];
    // Other ones such as Past, Future, and Technical Machines are not needed in this technical showcase.
    public BaseMove GetCurrentMove(uint currentMoveIndex)
    {
        return _currentMoves[currentMoveIndex];
    }
    public void SetCurrentMove(uint currentMoveIndex, string moveName)
    {
        _currentMoves[currentMoveIndex] = GameManager.GameInstance.NewMove(moveName);
    }
    public void SetAllMoves(string moveName1, string moveName2, string moveName3, string moveName4)
    {
        _currentMoves[0] = GameManager.GameInstance.NewMove("Struggle");
        _currentMoves[1] = GameManager.GameInstance.NewMove(moveName1);
        _currentMoves[2] = GameManager.GameInstance.NewMove(moveName2);
        _currentMoves[3] = GameManager.GameInstance.NewMove(moveName3);
        _currentMoves[4] = GameManager.GameInstance.NewMove(moveName4);
    }
    public byte GetAmountOfCurrentMoves()
    {
        return _amountOfCurrentMoves;
    }
}
