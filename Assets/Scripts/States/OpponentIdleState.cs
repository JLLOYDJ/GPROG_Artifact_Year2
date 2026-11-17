using UnityEngine;

public class OpponentIdleState : OpponentBaseState
{
    public override void Enter()
    {
        Debug.Log("Entering Into Waiting Mode");
        Execute();
    }
    public override void Execute()
    {
        Debug.Log("Waiting for Player to Finish");
    }
}
