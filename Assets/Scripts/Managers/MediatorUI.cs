using UnityEngine;

public abstract class MediatorUI : MonoBehaviour
{
    protected IUIMediator UIMediator;
    public void SetMediator(IUIMediator uimediator)
    {
        UIMediator = uimediator;
    }
}
