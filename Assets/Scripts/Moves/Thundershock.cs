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
        coreStats.SetTarget(Convert.ToByte(Target.enemy));
        coreType.SetPokemonType(Convert.ToByte(PokemonTypes.electric));
        SetPPMax(15);
        SetPPCurrent(GetPPMax());
        SetMovePower(Convert.ToByte(movePower.dexterity));
        diceLevel.SetAllLevelDice(1, 6, 1, 12, 2, 8, 4, 6);
    }

    public override void Activate()
    {
        // Checks if Action has been used, if not continue
        // checks for PP first and does PPFail if there is nothing
        // Grabs Singleton Manager, passes through player and opponent
        // Does a 20 roll with modifiers
        // checks level, and then finds dice amount and size
        // rolls with modifers added.
        // Goes to the Singleton Manager to pass the damage.

    }
}
