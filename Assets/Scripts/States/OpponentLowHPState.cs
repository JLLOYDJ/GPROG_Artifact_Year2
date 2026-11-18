using UnityEngine;

public class OpponentLowHPState : OpponentBaseState
{
    private bool[] moveHeal = new bool[5];
    private bool _MoveChosen = false;
    private bool _MoveAvailable = false;
    private uint _chosenMove;
    public override void Enter()
    {
        // I am ready to Heal, which move?
        for (uint i = 1; i < 5; i++)
        {
            if (GameManager.GameInstance.GetOpponentPokemon().moveSet.GetCurrentMove(i).GetMoveVariant() == moveVariant.Healing && GameManager.GameInstance.GetOpponentPokemon().moveSet.GetCurrentMove(i).PPCheck() == true)
            {
                moveHeal[i] = true;
                _MoveAvailable = true;
            }
            else
            {
                moveHeal[i] = false;
            }
        }

        if (_MoveAvailable == false)
        {
            if (GameManager.GameInstance.GetOpponentPokemon().buffDebuff.GetCurrentModifiedAttack() <= 0)
            {
                GameManager.EnemyAIState.ChangeState(new OpponentSetUpState());
            }
            else
            {
                GameManager.EnemyAIState.ChangeState(new OpponentAttackState());
            }
        }

        while (_MoveChosen == false)
        {
            uint chosenMove = System.Convert.ToUInt32(Random.Range(1, 5));
            if (moveHeal[chosenMove] == true)
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
        GameManager.GameInstance.GetOpponentPokemon().moveSet.GetCurrentMove(_chosenMove).Activate(GameManager.GameInstance.GetOpponentPokemon());
        TurnManager.TurnInstance.FinishTurn();
    }
}
