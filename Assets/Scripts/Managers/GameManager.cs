using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager GameInstance;
    public static MoveIndex currentMoveIndex = new MoveIndex();
    private BasePokemon PlayerPokemon;
    private BasePokemon OpponentPokemon;
    public static OpponentStateManager EnemyAIState = new OpponentStateManager();

    // Mediator Section (To Pass to UI)


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
        
        // Randomises which Pokemon Player Gets (Only 2 for this Artifact)
        // If I did the External Data, I would have used a builder as it would work best.
        // It wouldn't need multiple subclasses to ensure it passes through correctly.
        int pokemon = Random.Range(0, 2);
        if (pokemon == 0)
        {
            // Can Make into Game Objects if needed in future due to them now being monoBehaviour.
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
        TurnManager.TurnInstance.BeginBattle(PlayerPokemon, OpponentPokemon);
        Debug.Log(TurnManager.TurnInstance.CheckTurn());
    }

    /// <summary>
    /// This Function passes through the MoveIndex Result. (SCRAPPED due to linking issues)
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

    public bool PPTest(BasePokemon checkingPokemon)
    {
        byte remainingPP = 0;
        remainingPP += checkingPokemon.moveSet.GetCurrentMove(1).powerPoints.GetPPCurrent();
        remainingPP += checkingPokemon.moveSet.GetCurrentMove(2).powerPoints.GetPPCurrent();
        remainingPP += checkingPokemon.moveSet.GetCurrentMove(3).powerPoints.GetPPCurrent();
        remainingPP += checkingPokemon.moveSet.GetCurrentMove(4).powerPoints.GetPPCurrent();

        if (remainingPP == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void PPFail()
    {
        BasePokemon currentUser = TurnManager.TurnInstance.CheckTurn();
        bool _struggleTime = false;
        if (currentUser == PlayerPokemon)
        {
            _struggleTime = PPTest(PlayerPokemon);
            if (_struggleTime == true)
            {
                PlayerPokemon.moveSet.GetCurrentMove(0).Activate(PlayerPokemon);
            }
        }
        else
        {
            _struggleTime = PPTest(OpponentPokemon);
            if (_struggleTime == true)
            {
                OpponentPokemon.moveSet.GetCurrentMove(0).Activate(OpponentPokemon);
            }
        }

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

    public void DamageOther(uint amount, BasePokemon attacker, PokemonTypes moveType, string attackName)
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

            OpponentPokemon.coreStats.HPDamage(System.Convert.ToInt32(amount));
            if (OpponentPokemon.coreStats.GetCurrentHP() <= 0)
            {
                UIManager.UIInstance.AttackUpdate(attackName + " Used!\n Damage = " + amount + " on " + OpponentPokemon.coreID.GetName(), true);
                EndGame(false);
            }
            else
            {
                UIManager.UIInstance.AttackUpdate(attackName + " Used!\n Damage = " + amount + " on " + OpponentPokemon.coreID.GetName(), false);
            }
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

            PlayerPokemon.coreStats.HPDamage(System.Convert.ToInt32(amount));
            if (PlayerPokemon.coreStats.GetCurrentHP() <= 0)
            {
                UIManager.UIInstance.AttackUpdate(attackName + " Used!\n Damage = " + amount + " on " + PlayerPokemon.coreID.GetName(), true);
                EndGame(true);
            }
            else
            {
                UIManager.UIInstance.AttackUpdate(attackName + " Used!\n Damage = " + amount + " on " + PlayerPokemon.coreID.GetName(), false);
            }
        }
    }
    public void NextTurnDebug()
    {
        
        TurnManager.TurnInstance.FinishTurn();
    }
    public void EndGame(bool _playerLose)
    {
        EnemyAIState.ChangeState(new OpponentEndGameState());
        UIManager.UIInstance.GameEnding(_playerLose);
    }
}
