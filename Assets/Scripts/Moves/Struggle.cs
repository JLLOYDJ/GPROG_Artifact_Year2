using System;
using UnityEngine;

public class Struggle : BaseMove
{
    // To set all the variables for Struggle
    public Struggle() // Converted from Awake to Constructor so it would compile before runtime.
    {
        moveID.SetName("Struggle");
        moveID.SetDescription("This move is known by all Pokémon, and can be used at any time.\n" +
            "You lash out with an unarmed strike, or use an improvised weapon up close or at range to damage a creature.\n" +
            "Make a melee or ranged (60 feet) attack roll, doing damage equal to 2 + MOVE typeless damage on a hit.\n" +
            "The damage from this move cannot be increased by another move, item, or ability.");
        moveID.SetUniqueID(0);
        coreStats.SetAction(true);
        coreStats.SetDuration(0);
        coreStats.SetRange(60);
        coreStats.SetTarget(Convert.ToByte(Target.enemy));
        coreType.SetPokemonType(Convert.ToByte(PokemonTypes.typeless));
        // Doesn't need Level Increasing due to Struggle being basic
        powerPoints.SetPPMax(0);
        powerPoints.SetPPCurrent(powerPoints.GetPPMax());
        SetMovePower(Convert.ToByte(movePower.dexterity));
    }

    public override void Activate(BasePokemon User)
    {
        // Grabs Singleton Manager, passes through player and opponent
        // Does a 20 roll with modifiers
        // 2 + movePower for damage
        // Doesn't increase damage from moves or items or ability
        // No PP check as this is the if all else fails move.
    }
}
