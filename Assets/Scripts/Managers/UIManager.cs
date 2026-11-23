using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IUIMediator
{
    [SerializeField] private Canvas _uiCanvas;
    [SerializeField] private UIImage _playerImage;
    [SerializeField] private UIImage _opponentImage;
    [SerializeField] private UIButton _move1;
    [SerializeField] private UIButton _move2;
    [SerializeField] private UIButton _move3;
    [SerializeField] private UIButton _move4;
    [SerializeField] private UIButton _moveDesc1;
    [SerializeField] private UIButton _moveDesc2;
    [SerializeField] private UIButton _moveDesc3;
    [SerializeField] private UIButton _moveDesc4;
    [SerializeField] private UIButton _endTurn;
    [SerializeField] private UIText _moveDesc;
    [SerializeField] private UIText _playerHP;
    [SerializeField] private UIText _opponentHP;
    [SerializeField] private UIText _playerAction;
    [SerializeField] private UIText _playerBonusAction;
    [SerializeField] private UIText _endGameText;

    public static UIManager UIInstance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _playerImage.SetMediator(this);
        _opponentImage.SetMediator(this);
        _move1.SetMediator(this);
        _move2.SetMediator(this);
        _move3.SetMediator(this);
        _move4.SetMediator(this);
        _moveDesc1.SetMediator(this);
        _moveDesc2.SetMediator(this);
        _moveDesc3.SetMediator(this);
        _moveDesc4.SetMediator(this);
        _endTurn.SetMediator(this);
        _moveDesc.SetMediator(this);
        _playerHP.SetMediator(this);
        _opponentHP.SetMediator(this);
        _playerAction.SetMediator(this);
        _playerBonusAction.SetMediator(this);

        if (UIInstance == null)
        {
            UIInstance = this;
            DontDestroyOnLoad(UIInstance);
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        Initialisation();
    }

    public void Initialisation()
    {
        _playerImage.ImageSet(GameManager.GameInstance.GetPlayerPokemon(), false);
        _opponentImage.ImageSet(GameManager.GameInstance.GetOpponentPokemon(), true);
    }
    public void PlayerTurn()
    {
        _move1.Hiding(true);
        _move2.Hiding(true);
        _move3.Hiding(true);
        _move4.Hiding(true);
        _moveDesc1.Hiding(true);
        _moveDesc2.Hiding(true);
        _moveDesc3.Hiding(true);
        _moveDesc4.Hiding(true);
        _endTurn.Hiding(true);
        _moveDesc.Empty();
        _playerAction.Fill("===Action===\n" + GameManager.GameInstance.GetPlayerPokemon().actionResources.GetAction());
        _playerBonusAction.Fill("===Bonus Action===\n" + GameManager.GameInstance.GetPlayerPokemon().actionResources.GetBonusAction());
        HPUpdate();
        
    }
    public void OpponentTurn()
    {
        _move1.Hiding(false);
        _move2.Hiding(false);
        _move3.Hiding(false);
        _move4.Hiding(false);
        _moveDesc1.Hiding(false);
        _moveDesc2.Hiding(false);
        _moveDesc3.Hiding(false);
        _moveDesc4.Hiding(false);
        _endTurn.Hiding(false);
        _moveDesc.Empty();
        _playerAction.Empty();
        _playerBonusAction.Empty();
        HPUpdate();
    }

    public void TextDescriptionUpdate(uint moveIndex)
    {
        _moveDesc.Fill(GameManager.GameInstance.GetPlayerPokemon().moveSet.GetCurrentMove(moveIndex).moveID.GetDescription());
    }

    public void HPUpdate()
    {
        string playerHP;
        string opponentHP;

        playerHP = GameManager.GameInstance.GetPlayerPokemon().coreID.GetName() + "\nHP: " + GameManager.GameInstance.GetPlayerPokemon().coreStats.GetCurrentHP() + " / " + GameManager.GameInstance.GetPlayerPokemon().coreStats.GetMaxHP();
        opponentHP = GameManager.GameInstance.GetOpponentPokemon().coreID.GetName() + "\nHP: " + GameManager.GameInstance.GetOpponentPokemon().coreStats.GetCurrentHP() + " / " + GameManager.GameInstance.GetOpponentPokemon().coreStats.GetMaxHP();

        _playerHP.Fill(playerHP);
        _opponentHP.Fill(opponentHP);
    }

    public void AttackUpdate(string description, bool gameEnd)
    {
        StartCoroutine(MoveWait(description, gameEnd));
        
    }
    public IEnumerator MoveWait(string Desc, bool gameEnd)
    {
        OpponentTurn();
        yield return new WaitForSeconds(0.1f);
        _moveDesc.Fill(Desc);
        yield return new WaitForSeconds(3);
        if (gameEnd == false)
        {
            PlayerTurn();
        }
        else
        {
            _moveDesc.Empty();
        }


    }

    public void GameEnding(bool _playerLose)
    {
        GameEndWait();
        if (_playerLose)
        {
            _endGameText.Fill("Player Loses...");
        }
        else
        {
            _endGameText.Fill("Player Wins!!!");
        }
    }

    public IEnumerator GameEndWait()
    {
        yield return new WaitForSeconds(4.0f);
        OpponentTurn();
        _playerImage.GetComponent<Image>().enabled = false;
        _opponentImage.GetComponent<Image>().enabled = false;
        _moveDesc.Empty();
        _playerHP.Empty();
        _opponentHP.Empty();
    }

}
