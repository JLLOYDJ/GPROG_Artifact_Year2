using UnityEngine;
using UnityEngine.UI;

public class UIButton : MediatorUI
{
    [SerializeField]
    private uint _moveIndex;
    [SerializeField]
    private bool _isDesc;

    public void OnClick()
    {
        if (_isDesc)
        {
            Description();
        }
        else
        {
            Activation();
        }
    }

    public void Description()
    {
        UIMediator?.TextDescriptionUpdate(_moveIndex);
    }

    public void Activation()
    {
        GameManager.GameInstance.GetPlayerPokemon().moveSet.GetCurrentMove(_moveIndex).Activate(GameManager.GameInstance.GetPlayerPokemon());
        UIMediator.MoveActivated();
    }
    /// <summary>
    /// This section sets if the button hides. If true, it hides the button from screen.
    /// </summary>
    /// <param name="setHide"></param>
    public void Hiding(bool setVisible)
    {
        GetComponent<Image>().enabled = setVisible;
        GetComponentInChildren<Text>().enabled = setVisible;
       
    }
    
  
}
