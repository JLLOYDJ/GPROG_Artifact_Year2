using UnityEngine;

public class OpponentNoPPState : OpponentBaseState
{
    public override void Enter()
    {
        // Instead of being on Update, it is here because it doesn't need to keep checking like a realtime game.
        Execute();
    }
    public override void Execute()
    {
        Debug.Log("Struggle");
        GameManager.GameInstance.GetOpponentPokemon().moveSet.GetCurrentMove(0).Activate(GameManager.GameInstance.GetOpponentPokemon());
        if (GameManager.GameInstance.GetOpponentPokemon().coreStats.GetCurrentHP() != 0)
        {
            GameManager.TurnInstance.FinishTurn();
        }
        else
        {
            GameManager.EnemyAIState.ChangeState(new OpponentDeadState());
        }
    }
}
