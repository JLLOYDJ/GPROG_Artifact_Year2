using UnityEngine;

public abstract class OpponentBaseState :IState
{
    public abstract void Enter();
    public abstract void Execute();
}
