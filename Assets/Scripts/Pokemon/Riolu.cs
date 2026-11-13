using System;
using UnityEngine;
using UnityEngine.UI;

public class Riolu : BasePokemon
{
    public Riolu()
    {
        coreID.SetName("Riolu");
        coreID.SetDescription("The Emanation Pokémon.\n" +
            "The aura that emanates from its body intensifies to alert others if it is afraid or sad.");
        coreID.SetUniqueID(0447);
        additionalID.SetCurrentGender(true);
        additionalID.SetCurrentSR(0.5f);
        additionalID.SetCurrentNativeRegion("Sinnoh");
        additionalID.SetCurrentSize(Convert.ToByte(monsterSize.tiny));
        coreStats.SetAC(12);
        coreStats.SetAllStats(11, 13, 11, 8, 12, 10);
        coreStats.SetMaxHP(16);
        coreStats.SetCurrentHP(coreStats.GetMaxHP());
        coreStats.SetSavingThrowPer(Convert.ToByte(movePower.dexterity));
        coreStats.SetSpeed(30);
        level.SetCurrentLevel(1);
        level.SetMinimumLevel(1);
        moveSet.SetAllMoves("Tackle", "Growl", "Work Up", "Bullet Punch");
        mainType.SetPokemonType(Convert.ToByte(PokemonTypes.fighting));
        subType.SetPokemonType(Convert.ToByte(PokemonTypes.typeless));
        typeDefences.AddResistence(Convert.ToByte(PokemonTypes.bug));
        typeDefences.AddResistence(Convert.ToByte(PokemonTypes.dark));
        typeDefences.AddResistence(Convert.ToByte(PokemonTypes.rock));
        typeDefences.AddWeakness(Convert.ToByte(PokemonTypes.fairy));
        typeDefences.AddWeakness(Convert.ToByte(PokemonTypes.flying));
        typeDefences.AddWeakness(Convert.ToByte(PokemonTypes.psychic));
        SetFrontView((Texture2D)Resources.Load("Assets/Sprites/riolu_front.png"));
        SetRearView((Texture2D)Resources.Load("Assets/Sprites/riolu_rear.png"));
    }
}
