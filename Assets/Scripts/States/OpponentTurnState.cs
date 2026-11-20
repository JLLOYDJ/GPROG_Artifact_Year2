using UnityEngine;

public class OpponentTurnState : OpponentBaseState
{
    public override void Enter()
    {
        //YAY
        // Put the resource reset here in order for it to be enabled at the start of the TurnState.
        GameManager.GameInstance.GetOpponentPokemon().actionResources.NewTurnReset();
        // Instead of being on Update, it is here because it doesn't need to keep checking like a realtime game.
        Execute();
    }
    public override void Execute()
    {
        bool anyPP = GameManager.GameInstance.PPTest(GameManager.GameInstance.GetOpponentPokemon());
        if (anyPP)
        {
            if (GameManager.GameInstance.GetOpponentPokemon().coreStats.GetCurrentHP() <= (GameManager.GameInstance.GetOpponentPokemon().coreStats.GetCurrentHP() / 4))
            {
                GameManager.EnemyAIState.ChangeState(new OpponentLowHPState());
            }
            else if (GameManager.GameInstance.GetOpponentPokemon().buffDebuff.GetCurrentModifiedAttack() == 0)
            {
                GameManager.EnemyAIState.ChangeState(new OpponentSetUpState());
            }
            else
            {
                GameManager.EnemyAIState.ChangeState(new OpponentAttackState());
            }
        }
        else
        {
            GameManager.EnemyAIState.ChangeState(new OpponentNoPPState());
        }
    }
}
