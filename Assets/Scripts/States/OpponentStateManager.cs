using UnityEngine;

public class OpponentStateManager
{
    // This holds the current reference to the actice state in the machine.
    OpponentBaseState currentState;
    // All the different types of States so far.
    OpponentIdleState IdleState = new OpponentIdleState();
    OpponentDeadState DeadState = new OpponentDeadState();
    OpponentTurnState TurnState = new OpponentTurnState();
    OpponentAttackState AttackState = new OpponentAttackState();
    OpponentLowHPState LowHPState = new OpponentLowHPState();
    OpponentNoPPState NoPPState = new OpponentNoPPState();
    OpponentSetUpState SetUpState = new OpponentSetUpState();
    // Might make more in Future for more gradual control.

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void ChangeState(OpponentBaseState newState)
    {
        currentState = newState;
        newState.Enter();
    }
}
