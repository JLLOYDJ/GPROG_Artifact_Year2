using System;
using UnityEngine;

public class OpponentSetUpState : OpponentBaseState
{
    private bool[] moveBuff = new bool[5];
    private bool _MoveChosen = false;
    private bool _MoveAvailable = false;
    private uint _chosenMove;
    public override void Enter()
    {
        moveBuff[0] = false;
        // I am ready to Attack, which move?
        for (uint i = 1; i < 5; i++)
        {
            if ((GameManager.GameInstance.GetOpponentPokemon().moveSet.GetCurrentMove(i).GetMoveVariant() == moveVariant.Buff || GameManager.GameInstance.GetOpponentPokemon().moveSet.GetCurrentMove(i).GetMoveVariant() == moveVariant.Debuff) && GameManager.GameInstance.GetOpponentPokemon().moveSet.GetCurrentMove(i).PPCheck() == true)
            {
                moveBuff[i] = true;
                _MoveAvailable = true;
            }
            else
            {
                moveBuff[i] = false;
            }
        }

        if (_MoveAvailable == false)
        {
            GameManager.EnemyAIState.ChangeState(new OpponentLowHPState());
        }

        while (_MoveChosen == false)
        {
            uint chosenMove = Convert.ToUInt32(UnityEngine.Random.Range(1, 5));
            if (moveBuff[chosenMove] == true)
            {
                _chosenMove = chosenMove;
                _MoveChosen = true;
                // Instead of being on Update, it is here because it doesn't need to keep checking like a realtime game.
                Execute();
            }
        }
    }
    public override void Execute()
    {
        Debug.Log("SetUp from enemy");
        GameManager.GameInstance.GetOpponentPokemon().moveSet.GetCurrentMove(_chosenMove).Activate(GameManager.GameInstance.GetOpponentPokemon());
        GameManager.TurnInstance.FinishTurn();
    }
}
