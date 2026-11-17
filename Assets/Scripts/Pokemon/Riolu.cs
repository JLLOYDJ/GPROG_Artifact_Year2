using System;
using UnityEngine;
using UnityEngine.UI;

public class Riolu : BasePokemon
{
    // Note for the VIVA, if I was to do this again, I would consider doing external file - directory
    // All the pokemon use the same functions and items so if the game was bigger and good for a template.
    // This would then be extremely useful if the game expanded from this tech demo to a full game
    // As the amount of classes being created would be unvisible to keep as subclasses. 
    // So having an external directory would keep the originals and then the save system
    // would keep the individual Pokemon the player has due to them potentially being different
    // to the original template.
    public Riolu()
    {
        coreID.SetName("Riolu");
        coreID.SetDescription("The Emanation Pokémon.\n" +
            "The aura that emanates from its body intensifies to alert others if it is afraid or sad.");
        coreID.SetUniqueID(0447);
        additionalID.SetCurrentGender(true);
        additionalID.SetCurrentSR(0.5f);
        additionalID.SetCurrentNativeRegion("Sinnoh");
        additionalID.SetCurrentSize(monsterSize.tiny);
        coreStats.SetAC(12);
        coreStats.SetAllStats(11, 13, 11, 8, 12, 10);
        coreStats.SetMaxHP(16);
        coreStats.SetCurrentHP(coreStats.GetMaxHP());
        coreStats.SetSavingThrowPer(movePower.dexterity);
        coreStats.SetSpeed(30);
        level.SetCurrentLevel(1);
        level.SetMinimumLevel(1);
        moveSet.SetAllMoves("Tackle", "Growl", "Work Up", "Bullet Punch");
        mainType.SetPokemonType(PokemonTypes.fighting);
        subType.SetPokemonType(PokemonTypes.typeless);
        typeDefences.AddResistence(PokemonTypes.bug);
        typeDefences.AddResistence(PokemonTypes.dark);
        typeDefences.AddResistence(PokemonTypes.rock);
        typeDefences.AddWeakness(PokemonTypes.fairy);
        typeDefences.AddWeakness(PokemonTypes.flying);
        typeDefences.AddWeakness(PokemonTypes.psychic);
        // This wasn't working and that was due to me not using the correct way of loading Resources
        // Using Unity's Documentation, its just the file name and using the "as Texture2D"
        // So it knows what kind it needs to be.
        // Below is Original.
        //SetFrontView((Texture2D)Resources.Load("Assets/Sprites/riolu_front.png"));
        //SetRearView((Texture2D)Resources.Load("Assets/Sprites/riolu_rear.png"));
        // New Updated.
        SetRearString("Sprites/riolu_back");
        SetFrontString("Sprites/riolu_front");
    }
}
