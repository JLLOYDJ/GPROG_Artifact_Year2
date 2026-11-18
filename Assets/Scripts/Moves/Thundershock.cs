using System;
using UnityEditor.VersionControl;
using UnityEngine;

public class Thundershock : BaseMove
{
    // To set all the variables for Thundershock
    public DiceLevelIncrease diceLevel = new DiceLevelIncrease();
    public Thundershock() // Converted from Awake to Constructor so it would compile before runtime.
    {
        moveID.SetName("Thunder Shock");
        moveID.SetDescription("You deliver an electric shock to a target in range.\n" +
            "Make a ranged attack, doing 1d6 + MOVE electric damage on a hit.\n\n" +
            "At Higher Levels: The damage dice roll for this move changes to 1d12 at level 5, 2d8 at level 10, and 4d6 at level 17.");
        moveID.SetUniqueID(4);
        coreStats.SetAction(true);
        coreStats.SetDuration(0);
        coreStats.SetRange(20);
        coreStats.SetTarget(Target.enemy);
        coreType.SetPokemonType(PokemonTypes.electric);
        powerPoints.SetPPMax(15);
        powerPoints.SetPPCurrent(powerPoints.GetPPMax());
        SetMovePower(movePower.dexterity);
        diceLevel.SetAllLevelDice(1, 6, 1, 12, 2, 8, 4, 6);
        SetMoveVariant(moveVariant.Attack);
    }

    public override void Activate(BasePokemon User)
    {
        byte originalRoll;
        byte newRoll;
        bool IsAction = User.actionResources.GetAction();
        
        if (IsAction)
        {
            bool _isMoveAvailable = PPCheck();
            if (_isMoveAvailable)
            {
                powerPoints.ReducePPCurrent();
                User.actionResources.ActivateAction();
                newRoll = User.D20Roll(User.modifierArray.ModifierCalulator(User.coreStats.GetIndividualStat(GetMovePower())),
                    User.buffDebuff.GetCurrentModifiedAttack(),
                    DiceAdvantage.normal,
                    out originalRoll);
                bool doesHit = GameManager.GameInstance.ACTest(User, newRoll);
                if (doesHit)
                {
                    byte currentLevel = User.level.GetCurrentLevel();
                    int diceAmount = diceLevel.GetDiceAmount(currentLevel);
                    int diceSize = diceLevel.GetDiceSize(currentLevel);
                    int diceRoll = 0;
                    for (int i = 0; i < diceAmount; i++)
                    {
                        int random = UnityEngine.Random.Range(1, (diceSize + 1));
                        diceRoll += random;
                    }
                    int damageAmount = diceRoll + User.modifierArray.ModifierCalulator(User.coreStats.GetIndividualStat(GetMovePower()));
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
                    GameManager.GameInstance.DamageOther(Convert.ToUInt32(damageAmount), User, coreType.GetPokemonType(), moveID.GetName());
                }
                else
                {
                    UIManager.UIInstance.AttackUpdate("Thundershock Missed!\n Original Roll: " + originalRoll + "\nAfter Modifiers: " + newRoll);
                    return;
                }
            }
            else
            {
                UIManager.UIInstance.AttackUpdate("No PP Remaining for Thundershock");
                return;
            }
            // Checks if Action has been used, if not continue
            // checks for PP first and does PPFail if there is nothing
            // Grabs Singleton Manager, passes through player and opponent
            // Does a 20 roll with modifiers
            // checks level, and then finds dice amount and size
            // rolls with modifers added.
            // Goes to the Singleton Manager to pass the damage.

        }
        else
        {
            UIManager.UIInstance.AttackUpdate("No Action Remaining");
        }
    }
}
