using UnityEngine;
using UnityEngine.UI;

public class UIButton : MediatorUI
{
    [SerializeField]
    private uint _moveIndex;
    [SerializeField]
    private bool _isDesc;
    [SerializeField]
    private bool _isEndTurn;

    private Color _colorAction = new Vector4(0, 255, 0, 255);
    private Color _colorBonus = new Vector4(125, 125, 0, 255);

    public void Start()
    {
        if (_isDesc)
        {
            GetComponentInChildren<Text>().text = "Move " + _moveIndex+ " Desc";
        }
        else if (_isEndTurn)
        {
            GetComponentInChildren<Text>().text = "End Turn";
        }
        else
        {
            UpdateText();
            if (GameManager.GameInstance.GetPlayerPokemon().moveSet.GetCurrentMove(_moveIndex).coreStats.GetAction() == true)
            {
                GetComponent<Image>().color = _colorAction;
            }
            else
            {
                GetComponent<Image>().color = _colorBonus;
            }
        }
        
    }

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
    }
    /// <summary>
    /// This section sets if the button hides. If true, it hides the button from screen.
    /// </summary>
    /// <param name="setHide"></param>
    public void Hiding(bool setVisible)
    {
        GetComponent<Image>().enabled = setVisible;
        GetComponentInChildren<Text>().enabled = setVisible;
        UpdateText();
       
    }
    
    public void UpdateText()
    {
        if (_isDesc == false && _isEndTurn == false)
        {
            GetComponentInChildren<Text>().text = GameManager.GameInstance.GetPlayerPokemon().moveSet.GetCurrentMove(_moveIndex).moveID.GetName() + " " + GameManager.GameInstance.GetPlayerPokemon().moveSet.GetCurrentMove(_moveIndex).powerPoints.GetPPCurrent() + "/" + GameManager.GameInstance.GetPlayerPokemon().moveSet.GetCurrentMove(_moveIndex).powerPoints.GetPPMax();
        }
        
    }
  
}
