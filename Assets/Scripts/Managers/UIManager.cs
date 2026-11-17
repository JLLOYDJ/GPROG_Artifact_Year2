using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static Canvas uiCanvasInstance;
    // This allows the grabbing of images within the scene so they can be edited to be the users pokemon.
    private static GameObject _playerImage;
    private static GameObject _opponentImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        uiCanvasInstance = FindAnyObjectByType<Canvas>();
        _playerImage = GameObject.FindWithTag("Player");
        _opponentImage = GameObject.FindWithTag("Enemy");

        if (_playerImage == null)
        {
            Debug.Log("image not found");
        }
        if (_opponentImage == null)
        {
            Debug.Log("Opponent image not found");
        }
    }
    void Start()
    {
        UpdateSprites();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSprites()
    {
        // Updated System using the setting of Texture 2D as the sprites within the game.
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


}
