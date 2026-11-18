using System.Runtime.CompilerServices;
using UnityEngine;
using System;

public class OpponentAttackState : OpponentBaseState
{
    private bool[] moveAttack = new bool[5];
    private bool _MoveChosen = false;
    private bool _MoveAvailable = false;
    private uint _chosenMove;
    public override void Enter()
    {
        // I am ready to Attack, which move?
        for (uint i = 1; i < 5; i++)
        {
            if (GameManager.GameInstance.GetOpponentPokemon().moveSet.GetCurrentMove(i).GetMoveVariant() == moveVariant.Attack && GameManager.GameInstance.GetOpponentPokemon().moveSet.GetCurrentMove(i).PPCheck() == true)
            {
                moveAttack[i] = true;
                _MoveAvailable = true;
            }
            else
            {
                moveAttack[i] = false;
            }
        }

        if (_MoveAvailable == false)
        {
            GameManager.EnemyAIState.ChangeState(new OpponentLowHPState());
        }

        while (_MoveChosen == false)
        {
            uint chosenMove = Convert.ToUInt32(UnityEngine.Random.Range(1, 5));
            if (moveAttack[chosenMove] == true)
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
        Debug.Log("AttackFromEnemy");
        GameManager.GameInstance.GetOpponentPokemon().moveSet.GetCurrentMove(_chosenMove).Activate(GameManager.GameInstance.GetOpponentPokemon());
        if (GameManager.GameInstance.GetOpponentPokemon().coreStats.GetCurrentHP() != 0)
        {
            TurnManager.TurnInstance.FinishTurn();
        }
        else
        {
            GameManager.EnemyAIState.ChangeState(new OpponentDeadState());
        }
    }
}