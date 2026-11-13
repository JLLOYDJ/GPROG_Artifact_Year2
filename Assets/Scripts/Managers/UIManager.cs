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
    }
    void Start()
    {
        _playerImage.gameObject.GetComponent<Image>().overrideSprite = Sprite.Create(GameManager.GameInstance.GetPlayerPokemon().GetRearView(),
            new Rect(0, 0, GameManager.GameInstance.GetPlayerPokemon().GetRearView().width, 
            GameManager.GameInstance.GetPlayerPokemon().GetRearView().height), 
            new Vector2(GameManager.GameInstance.GetPlayerPokemon().GetRearView().width / 2, 
            GameManager.GameInstance.GetPlayerPokemon().GetRearView().height / 2));
        _opponentImage.gameObject.GetComponent<Image>().overrideSprite = Sprite.Create(GameManager.GameInstance.GetOpponentPokemon().GetFrontView(),
            new Rect(0, 0, GameManager.GameInstance.GetOpponentPokemon().GetFrontView().width,
            GameManager.GameInstance.GetOpponentPokemon().GetFrontView().height),
            new Vector2(GameManager.GameInstance.GetOpponentPokemon().GetFrontView().width / 2,
            GameManager.GameInstance.GetOpponentPokemon().GetRearView().height / 2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
