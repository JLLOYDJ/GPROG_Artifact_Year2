using UnityEngine;

public class ActionBonusAction
{
    private bool _actionAvailable = true;
    private bool _bonusActionAvailable = true;
    public bool GetAction()
    {
        return _actionAvailable;
    }
    public bool GetBonusAction()
    {
        return _bonusActionAvailable;
    }
    public void ActivateAction()
    {
        _actionAvailable = false;
    }
    public void ActivateBonusAction()
    {
        _bonusActionAvailable = false;
    }
    public void NewTurnReset()
    {
        _actionAvailable = true;
        _bonusActionAvailable = true;
    }
}
