using NUnit.Framework.Internal.Filters;
using UnityEngine;

public class CoreMoves
{
    private static uint _amountOfCurrentMoves;
    private BaseMove[] _currentMoves = new BaseMove[_amountOfCurrentMoves];
    // Other ones such as Past, Future, and Technical Machines are not needed in this technical showcase.
    public BaseMove GetCurrentMove(uint currentMoveIndex)
    {
        return _currentMoves[currentMoveIndex];
    }
    public void SetCurrentMove(uint currentMoveIndex, uint moveID)
    {
        _currentMoves[currentMoveIndex] = GameManager.GameInstance.NewMove(moveID);
    }
    public void SetAllMoves(uint moveID1, uint moveID2, uint moveID3, uint moveID4)
    {
        _currentMoves[0] = GameManager.GameInstance.NewMove(moveID1);
        _currentMoves[1] = GameManager.GameInstance.NewMove(moveID2);
        _currentMoves[2] = GameManager.GameInstance.NewMove(moveID3);
        _currentMoves[3] = GameManager.GameInstance.NewMove(moveID4);
    }
}
