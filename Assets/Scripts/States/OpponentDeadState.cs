using UnityEngine;

public class OpponentDeadState : OpponentBaseState
{
    public override void Enter()
    {
        if (GameManager.GameInstance.GetOpponentPokemon().coreStats.GetCurrentHP() != 0)
        {
            GameManager.EnemyAIState.ChangeState(new OpponentIdleState());
        }
        else
        {
            Execute();
        }

    }
    public override void Execute()
    {
        GameManager.GameInstance.EndGame(false);
        GameManager.EnemyAIState.ChangeState(new OpponentEndGameState());
    }

}
