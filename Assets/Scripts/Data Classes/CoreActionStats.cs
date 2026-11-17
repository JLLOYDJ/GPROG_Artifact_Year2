using System;
using UnityEngine;
[Serializable]
public class CoreActionStats
{
    private uint _duration = 0;
    private uint _range = 0;
    // Originally a byte, but as found out, you can use the enum itself for this as the variable type.
    private Target _target = Target.self; 
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

    public Target GetTarget()
    {
        return _target;
    }

    public void SetTarget(Target newTarget)
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
