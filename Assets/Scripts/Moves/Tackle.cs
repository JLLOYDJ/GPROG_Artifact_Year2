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
        SetPPMax(20);
        SetPPCurrent(GetPPMax());
        SetMovePower(Convert.ToByte(movePower.strength));
        diceLevel.SetAllLevelDice(1, 6, 1, 10, 2, 8, 5, 4);
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
