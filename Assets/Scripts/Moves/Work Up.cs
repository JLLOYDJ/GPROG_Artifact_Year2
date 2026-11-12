using System;
using UnityEngine;

public class WorkUp : BaseMove
{
    public WorkUp() // Converted from Awake to Constructor so it would compile before runtime.
    {
        moveID.SetName("Work Up");
        moveID.SetDescription("You get your adrenaline pumping and go into a frenzy.\n" +
            "While worked up, you add +2 to all attack rolls.\n" +
            "Your worked up status ends if you are incapacitated\n" +
            "or if your turn ends and you have not attacked a hostile target since your last turn,\n" +
            "or taken any damage since then.");
        moveID.SetUniqueID(3);
        coreStats.SetAction(false);
        coreStats.SetDuration(10);
        coreStats.SetRange(0);
        coreStats.SetTarget(Convert.ToByte(Target.self));
        coreType.SetPokemonType(Convert.ToByte(PokemonTypes.normal));
        // Doesn't need Level Increasing due to being a modifier
        SetPPMax(3);
        SetPPCurrent(GetPPMax());
        SetMovePower(Convert.ToByte(movePower.none));
    }

    public override void Activate()
    {
        // Checks if Bonus Action has been used, if not continue
        // checks for PP first and does PPFail if there is nothing
        // Grabs Singleton Manager, passes through player and opponent
        // Add +2 to modifier, if player doesn't attack, it ends.
        // Add timer to buff (Maybe list or Dictonary for keeping track of these).

    }
}
