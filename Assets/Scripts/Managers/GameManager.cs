using UnityEditor.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GameInstance;
    public static UIManager UIInstance;
    public static MoveIndex currentMoveIndex = new MoveIndex();
    private BasePokemon PlayerPokemon;
    private BasePokemon OpponentPokemon;

    // Mediator Section


    // Using this section to build out Mediator since it has a bunch of things that the whole system will need to see.
    void Awake()
    {
        // This section makes the Game Manager into a Singleton as only 1 needs to be working during gameplay.
        if (GameInstance == null)
        {
            GameInstance = this;
            DontDestroyOnLoad(GameInstance);
        }
        else
        {
            Destroy(gameObject);
        }
        // Creating the new Game UI Manager to use. (Singleton since only 1 needs to be in the world.
        if (UIInstance == null)
        {
            UIInstance = new GameObject("UIManager").AddComponent<UIManager>();
            DontDestroyOnLoad(UIInstance);
        }
        
        // Randomises which Pokemon Player Gets (Only 2 for this Artifact)
        int pokemon = Random.Range(0, 2);
        if (pokemon == 0)
        {
            PlayerPokemon = new Pikachu();
            OpponentPokemon = new Riolu();
        }
        else
        {
            PlayerPokemon = new Riolu();
            OpponentPokemon = new Pikachu();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NewMove("Tackle");
        PlayerPokemon.moveSet.GetCurrentMove(3);
        PlayerPokemon.moveSet.GetCurrentMove(0).Activate(PlayerPokemon);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This Function passes through the MoveIndex Result.
    /// </summary>
    /// <param name="moveName"></param>
    /// <returns></returns>
    public BaseMove NewMove(string moveName)
    {
        return currentMoveIndex.IDMoveReturn(moveName);
    }
    public BasePokemon GetPlayerPokemon()
    {
        return PlayerPokemon;
    }
    public BasePokemon GetOpponentPokemon()
    {
        return OpponentPokemon;
    }

    public void PPTest(BasePokemon checkingPokemon)
    {

    }

    public bool ACTest(BasePokemon checkingPokemon, byte diceRoll)
    {
        byte ACNumber;
        if (checkingPokemon == PlayerPokemon)
        {
            ACNumber = OpponentPokemon.coreStats.GetAC();
        }
        else
        {
            ACNumber = PlayerPokemon.coreStats.GetAC();
        }

        if (ACNumber > diceRoll)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void DamageOther(uint amount, BasePokemon attacker, byte moveType)
    {
        if (attacker == PlayerPokemon)
        {
            bool weakness = OpponentPokemon.typeDefences.GetWeaknesses().Contains(moveType);
            if (weakness == true)
            {
                amount *= 2;
            }
            bool resistance = OpponentPokemon.typeDefences.GetResistences().Contains(moveType);
            if (resistance == true)
            {
                // Doing this saves another Convert.
                amount *= 5;
                amount /= 10;
            }
            bool immunity = OpponentPokemon.typeDefences.GetImmunities().Contains(moveType);
            if (immunity == true)
            {
                amount = 0;
            }

            OpponentPokemon.coreStats.HPDamage(amount);
            Debug.Log(amount + "To Enemy");
        }
        else
        {
            bool weakness = PlayerPokemon.typeDefences.GetWeaknesses().Contains(moveType);
            if (weakness == true)
            {
                amount *= 2;
            }
            bool resistance = PlayerPokemon.typeDefences.GetResistences().Contains(moveType);
            if (resistance == true)
            {
                // Doing this saves another Convert.
                amount *= 5;
                amount /= 10;
            }
            bool immunity = PlayerPokemon.typeDefences.GetImmunities().Contains(moveType);
            if (immunity == true)
            {
                amount = 0;
            }

            PlayerPokemon.coreStats.HPDamage(amount);
            Debug.Log(amount + "To Enemy");
        }
    }
}
