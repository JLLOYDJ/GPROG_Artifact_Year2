using System;
using UnityEngine;

public class Tackle : BaseMove
{
    // To set all the variables for Tackle
    public DiceLevelIncrease diceLevel = new DiceLevelIncrease();
    public Tackle() // Converted from Awake to Constructor so it would compile before runtime.
    {
        moveID.SetName("Tackle");
        moveID.SetDescription("You rush forward and slam into a creature.\n" +
            "Make a melee attack roll against a target, doing 1d6 + MOVE normal damage on a hit.\n\n" +
            "At Higher Levels: The damage dice roll for this move changes to 1d10 at level 5, 2d8 at level 10, and 5d4 at level 17.");
        moveID.SetUniqueID(1);
        coreStats.SetAction(true);
        coreStats.SetDuration(0);
        coreStats.SetRange(5);
        coreStats.SetTarget(Convert.ToByte(Target.enemy));
        coreType.SetPokemonType(Convert.ToByte(PokemonTypes.normal));
        powerPoints.SetPPMax(20);
        powerPoints.SetPPCurrent(powerPoints.GetPPMax());
        SetMovePower(Convert.ToByte(movePower.strength));
        diceLevel.SetAllLevelDice(1, 6, 1, 10, 2, 8, 5, 4);
    }

    public override void Activate(BasePokemon User)
    {
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
                byte originalRoll;
                byte newRoll;
                newRoll = User.D20Roll(User.modifierArray.ModifierCalulator(User.coreStats.GetIndividualStat(GetMovePower())),
                    User.buffDebuff.GetCurrentModifiedAttack(), 
                    Convert.ToByte(DiceAdvantage.normal), 
                    out originalRoll);
                bool doesHit = GameManager.GameInstance.ACTest(User, newRoll);
                if (doesHit)
                {
                    Debug.Log("HITS!");
                    byte currentLevel = User.level.GetCurrentLevel();
                    byte diceAmount = diceLevel.GetDiceAmount(currentLevel);
                    byte diceSize = diceLevel.GetDiceSize(currentLevel);
                    byte diceRoll = 0;
                    for (int i = 0; i < diceAmount; i++)
                    {
                        diceRoll += Convert.ToByte(UnityEngine.Random.Range(1, (diceAmount + 1)));
                    }
                    Convert.ToByte(diceAmount * diceSize);
                    uint damageAmount = (Convert.ToUInt32(diceRoll + User.modifierArray.ModifierCalulator(User.coreStats.GetIndividualStat(GetMovePower()))));
                    if (originalRoll == 20)
                    {
                        damageAmount += diceRoll; // Doubling Dice Roll
                    }
                    if (User.mainType.GetPokemonType() == coreType.GetPokemonType() || User.subType.GetPokemonType() == coreType.GetPokemonType())
                    {
                        // Saving doing another convert.
                        damageAmount *= 15;
                        damageAmount /= 10;
                    }
                    GameManager.GameInstance.DamageOther(damageAmount, User, coreType.GetPokemonType());
                }
                else
                {
                    Debug.Log("UI Here, Update to show it missed");
                }
            }
            else
            {
                return;
            }
        }    
        // Checks if Action has been used, if not continue
        // checks for PP first and does PPFail if there is nothing
        // Grabs Singleton Manager, passes through player and opponent
        // Does a 20 roll with modifiers
        // checks level, and then finds dice amount and size
        // rolls with modifers added.
        // Goes to the Singleton Manager to pass the damage.

    }
}
