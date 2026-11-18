using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField]
    private uint _moveIndex;
    [SerializeField]
    private bool _isDesc;

    private bool _isShowing;

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
        if (_isShowing)
        {

        }
        else
        {

        }
    }

    public void Activation()
    {
        GameManager.GameInstance.GetPlayerPokemon().moveSet.GetCurrentMove(_moveIndex).Activate(GameManager.GameInstance.GetPlayerPokemon());
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
