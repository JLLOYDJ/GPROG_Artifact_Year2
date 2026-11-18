using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

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

    public static UIManager UIInstance;
    // This allows the grabbing of images within the scene so they can be edited to be the users pokemon.
    //private static GameObject _playerImage;
    //private static GameObject _opponentImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _playerImage.SetMediator(this);
        _opponentImage.SetMediator(this);
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

    // Update is called once per frame
    void Update()
    {
        
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
    }
    public void UpdateSprites()
    {
        // Updated System using the setting of Texture 2D as the sprites within the game.
        // Now defunct as it has been passed to UIIMage code as this is the mediator.
        Texture2D playerImage = Resources.Load<Texture2D>(GameManager.GameInstance.GetPlayerPokemon().GetRearString());
        Texture2D opponentImage = Resources.Load<Texture2D>(GameManager.GameInstance.GetOpponentPokemon().GetFrontString());
        _playerImage.gameObject.GetComponent<Image>().overrideSprite = Sprite.Create(playerImage, new Rect(0, 0, playerImage.width, playerImage.height), new Vector2(playerImage.width / 2, playerImage.height / 2));
        _opponentImage.gameObject.GetComponent<Image>().overrideSprite = Sprite.Create(opponentImage, new Rect(0, 0, opponentImage.width, opponentImage.height), new Vector2(opponentImage.width / 2, opponentImage.height / 2));

        // Original way, while working wasn't as optimal as it will call to the game manager multiple times.
        /*_playerImage.gameObject.GetComponent<Image>().overrideSprite = Sprite.Create(GameManager.GameInstance.GetPlayerPokemon().GetRearView(),
            new Rect(0, 0, GameManager.GameInstance.GetPlayerPokemon().GetRearView().width,
            GameManager.GameInstance.GetPlayerPokemon().GetRearView().height),
            new Vector2(GameManager.GameInstance.GetPlayerPokemon().GetRearView().width / 2,
            GameManager.GameInstance.GetPlayerPokemon().GetRearView().height / 2));
        _opponentImage.gameObject.GetComponent<Image>().overrideSprite = Sprite.Create(GameManager.GameInstance.GetOpponentPokemon().GetFrontView(),
            new Rect(0, 0, GameManager.GameInstance.GetOpponentPokemon().GetFrontView().width,
            GameManager.GameInstance.GetOpponentPokemon().GetFrontView().height),
            new Vector2(GameManager.GameInstance.GetOpponentPokemon().GetFrontView().width / 2,
            GameManager.GameInstance.GetOpponentPokemon().GetRearView().height / 2));*/
    }

    public void DiceRoll()
    {

    }
}
