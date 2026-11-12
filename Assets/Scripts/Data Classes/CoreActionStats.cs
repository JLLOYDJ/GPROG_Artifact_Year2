using System;
using UnityEngine;

public class CoreActionStats
{
    private uint _duration = 0;
    private uint _range = 0;
    private int _target = Convert.ToInt32(Target.self); // Originally byte, however, it only goes to 255, doesn't do minuses.
    private bool _isAction = false; // False = BonusAction, True = Action

    public uint GetDuration()
    {
        return _duration;
    }

    public void SetDuration(uint newDuration)
    {
        _duration = newDuration;
    }

    public uint GetRange()
    {
        return _range;
    }

    public void SetRange(uint newRange)
    {
        _range = newRange;
    }

    public int GetTarget()
    {
        return _target;
    }

    public void SetTarget(int newTarget)
    {
        _target = newTarget;
    }

    public bool GetAction()
    {
        return _isAction;
    }

    public void SetAction(bool newIsAction)
    {
        _isAction = newIsAction;
    }

}
