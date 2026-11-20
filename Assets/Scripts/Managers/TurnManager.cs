using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class TurnManager : MonoBehaviour, ID20
{
    // Creating the new Game UI Manager to use. (Singleton since only 1 needs to be in the world.
    // Same as before, doing this for the Turn Manager
    public static TurnManager TurnInstance;
    void Awake()
    {
        if (TurnInstance == null)
        {
            TurnInstance = this;
            DontDestroyOnLoad(TurnInstance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Creating the queue that takes the Pokemon's reference and 
    private Queue <BasePokemon> TurnOrder = new Queue<BasePokemon>();

    public void AddTurn(BasePokemon referencePokemon)
    {
        TurnOrder.Enqueue(referencePokemon);
    }

    public BasePokemon CheckTurn()
    {
        return TurnOrder.Peek();
    }

    public void FinishTurn()
    {
        StartCoroutine(TurnWait(CheckTurn()));
    }

    public void StartTurn()
    {
        if (CheckTurn() == GameManager.GameInstance.GetPlayerPokemon())
        {
            GameManager.EnemyAIState.ChangeState(new OpponentIdleState());
            GameManager.GameInstance.GetPlayerPokemon().actionResources.NewTurnReset();
            UIManager.UIInstance.PlayerTurn();
            
            // Opponent Turn ended and begin player turn.
        }
        else
        {
            GameManager.EnemyAIState.ChangeState(new OpponentTurnState());
            UIManager.UIInstance.OpponentTurn();

            // Activate Opponent's State
        }
    }

    public void BeginBattle(BasePokemon playerPokemon, BasePokemon opponentPokemon)
    {
        byte playerRoll = InitiativeCal(playerPokemon.modifierArray.ModifierCalulator(playerPokemon.coreStats.GetIndividualStat(movePower.dexterity)));
        byte opponentRoll = InitiativeCal(opponentPokemon.modifierArray.ModifierCalulator(opponentPokemon.coreStats.GetIndividualStat(movePower.dexterity)));
        
        if (playerRoll >= opponentRoll)
        {
            AddTurn(playerPokemon);
            AddTurn(opponentPokemon);
        }
        else
        {
            AddTurn(opponentPokemon);
            AddTurn(playerPokemon);
        }
        StartTurn();
    }

    public byte InitiativeCal(int dexModifer)
    {
        byte rollOriginal;
        return D20Roll(dexModifer, 0, DiceAdvantage.normal, out rollOriginal);
    }

    // Cannot be private because of Interface
    public byte D20Roll(int _Modifier, int _buff, DiceAdvantage _advantage, out byte _originalResult)
    {
        int diceRoll = UnityEngine.Random.Range(1, 21);
        _originalResult = Convert.ToByte(diceRoll);
        diceRoll += _Modifier;
        return Convert.ToByte(diceRoll);
    }

    public IEnumerator TurnWait(BasePokemon User)
    {
        if (User != GameManager.GameInstance.GetPlayerPokemon())
        {
            yield return new WaitForSeconds(3);
        }
        AddTurn(CheckTurn());
        TurnOrder.Dequeue();
        StartTurn();
    }
}
