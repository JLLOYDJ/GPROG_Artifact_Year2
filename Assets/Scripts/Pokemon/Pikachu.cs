using UnityEngine;
using System;

public class Pikachu : BasePokemon
{
    public Pikachu()
    {
        coreID.SetName("Pikachu");
        coreID.SetDescription("The Mouse Pokémon.\n" +
            "This forest-dwelling Pokémon stores electricity in its cheeks, " +
            "so you’ll feel a tingly shock if you touch it.");
        coreID.SetUniqueID(0025);
        additionalID.SetCurrentGender(true);
        additionalID.SetCurrentSR(0.5f);
        additionalID.SetCurrentNativeRegion("Kanto");
        additionalID.SetCurrentSize(Convert.ToByte(monsterSize.tiny));
        coreStats.SetAC(13);
        coreStats.SetAllStats(11,15,10,6,10,12);
        coreStats.SetMaxHP(16);
        coreStats.SetCurrentHP(coreStats.GetMaxHP());
        coreStats.SetSavingThrowPer(Convert.ToByte(movePower.dexterity));
        coreStats.SetSpeed(30);
        level.SetCurrentLevel(1);
        level.SetMinimumLevel(1);
        moveSet.SetAllMoves("Tackle", "Growl", "Work Up", "Thunder Shock");
        mainType.SetPokemonType(Convert.ToByte(PokemonTypes.electric));
        subType.SetPokemonType(Convert.ToByte(PokemonTypes.typeless));
        typeDefences.AddResistence(Convert.ToByte(PokemonTypes.electric));
        typeDefences.AddResistence(Convert.ToByte(PokemonTypes.flying));
        typeDefences.AddResistence(Convert.ToByte(PokemonTypes.steel));
        typeDefences.AddWeakness(Convert.ToByte(PokemonTypes.ground));
        SetFrontView((Texture2D)Resources.Load("Assets/Sprites/pikachu_front.png"));
        SetRearView((Texture2D)Resources.Load("Assets/Sprites/pikachu_rear.png"));
        
    }
}
