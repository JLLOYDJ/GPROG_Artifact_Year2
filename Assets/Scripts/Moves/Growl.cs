using System;
using UnityEngine;

public class Growl : BaseMove
{
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
        coreStats.SetTarget(Convert.ToByte(Target.enemy));
        coreType.SetPokemonType(Convert.ToByte(PokemonTypes.normal));
        // Doesn't need Level Increasing due to being a modifier
        powerPoints.SetPPMax(20);
        powerPoints.SetPPCurrent(powerPoints.GetPPMax());
        SetMovePower(Convert.ToByte(movePower.charisma));
    }

    public override void Activate(BasePokemon User)
    {
        // Checks if Action has been used, if not continue
        // checks for PP first and does PPFail if there is nothing
        // Grabs Singleton Manager, passes through player and opponent
        // Get Opponent to do a Wisdom or Cha saving throw
        // On fail, check if growl already succeeded before, if so, check if it is below 5.
        // If so, -1 upto -5 on the oppontent.

    }
}
