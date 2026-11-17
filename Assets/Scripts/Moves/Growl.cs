using System;
using UnityEngine;

public class Growl : BaseMove
{
    private byte GrowlUses = 0;
    public Growl() // Converted from Awake to Constructor so it would compile before runtime.
    {
        moveID.SetName("Growl");
        moveID.SetDescription("You target a creature with an intimidating growl.\n" +
            "The creature must make a WIS save against your Move DC.\n" +
            "On a fail, it adds -1 to any attack it makes for the duration.\n" +
            "This modifier can be stacked if it fails multiple growl saves, up to a maximum of -5.");
        moveID.SetUniqueID(2);
        coreStats.SetAction(true);
        coreStats.SetDuration(10);
        coreStats.SetRange(100);
        coreStats.SetTarget(Target.enemy);
        coreType.SetPokemonType(PokemonTypes.normal);
        // Doesn't need Level Increasing due to being a modifier
        powerPoints.SetPPMax(20);
        powerPoints.SetPPCurrent(powerPoints.GetPPMax());
        SetMovePower(movePower.charisma);
        SetMoveVariant(moveVariant.Debuff);

    }

    public override void Activate(BasePokemon User)
    {
        // Checks if Action has been used, if not continue
        // checks for PP first and does PPFail if there is nothing
        // Grabs Singleton Manager, passes through player and opponent
        // Get Opponent to do a Wisdom or Cha saving throw
        // On fail, check if growl already succeeded before, if so, check if it is below 5.
        // If so, -1 upto -5 on the oppontent.

        // Havent Implemented yet, but looking into making a reset for Growl when it has been past 10 rounds.
        Debug.Log("ACTIVATED!");

        bool IsAction = User.actionResources.GetAction();
        Debug.Log(IsAction);
        if (IsAction)
        {
            bool _isMoveAvailable = PPCheck();
            if (_isMoveAvailable)
            {
                powerPoints.ReducePPCurrent();
                User.actionResources.ActivateAction();
                byte savingThrowOpponent;
                byte opponentOriginalRoll;
                if (User == GameManager.GameInstance.GetOpponentPokemon())
                {
                    savingThrowOpponent = GameManager.GameInstance.GetPlayerPokemon().D20Roll(GameManager.GameInstance.GetPlayerPokemon().coreStats.GetIndividualStat(GetMovePower()),
                        GameManager.GameInstance.GetPlayerPokemon().buffDebuff.GetCurrentModifiedAttack(),
                        DiceAdvantage.normal, out opponentOriginalRoll);
                }
                else
                {
                    savingThrowOpponent = GameManager.GameInstance.GetOpponentPokemon().D20Roll(GameManager.GameInstance.GetOpponentPokemon().coreStats.GetIndividualStat(GetMovePower()),
                        GameManager.GameInstance.GetOpponentPokemon().buffDebuff.GetCurrentModifiedAttack(),
                        DiceAdvantage.normal, out opponentOriginalRoll);
                }
                byte savingThrowDC = User.SavingThrowCal(User.modifierArray.ModifierCalulator(User.coreStats.GetIndividualStat(GetMovePower())),
                    User.buffDebuff.GetCurrentModifiedAttack(),
                    User.proficiencyBonus.GetProficiencyBonus());

                if (savingThrowDC >= savingThrowOpponent && GrowlUses < 5)
                {
                    if (User == GameManager.GameInstance.GetOpponentPokemon())
                    {
                        GameManager.GameInstance.GetOpponentPokemon().buffDebuff.NewBuffDebuffAttack(-1, coreStats.GetDuration());
                    }
                    else
                    {
                        GameManager.GameInstance.GetPlayerPokemon().buffDebuff.NewBuffDebuffAttack(-1, coreStats.GetDuration());
                    }
                    GrowlUses += 1;
                }
                else if (savingThrowDC >= savingThrowOpponent && GrowlUses == 5)
                {
                    Debug.Log("Max of 5 active growls have been used.");
                }
                else
                {
                    Debug.Log("UI Here, Update to show it missed");
                }

            }
        }
    }
}
