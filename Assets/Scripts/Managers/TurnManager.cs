using System;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour, ID20
{
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
        AddTurn(CheckTurn());
        TurnOrder.Dequeue();
    }

    public void BeginBattle(BasePokemon playerPokemon, BasePokemon opponentPokemon)
    {
        byte playerRoll = InitiativeCal(playerPokemon.modifierArray.ModifierCalulator(playerPokemon.coreStats.GetIndividualStat(movePower.dexterity)));
        byte opponentRoll = InitiativeCal(opponentPokemon.modifierArray.ModifierCalulator(opponentPokemon.coreStats.GetIndividualStat(movePower.dexterity)));
        
        if (playerRoll > opponentRoll)
        {
            AddTurn(playerPokemon);
            AddTurn(opponentPokemon);
        }
        else if (opponentRoll > playerRoll)
        {
            AddTurn(opponentPokemon);
            AddTurn(playerPokemon);
        }
        else
        {
            if(playerPokemon.coreStats.GetIndividualStat(movePower.dexterity) >= opponentPokemon.coreStats.GetIndividualStat(movePower.dexterity))
            {
                AddTurn(playerPokemon);
                AddTurn(opponentPokemon);
            }
            else
            {
                AddTurn(opponentPokemon);
                AddTurn(playerPokemon);
            }
        }
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
}
