using UnityEngine;
using System;

public class Pikachu : BasePokemon
{
    // Note for the VIVA, if I was to do this again, I would consider doing external files - directory
    // All the pokemon use the same functions and items so if the game was bigger and good for a template.
    // This would then be extremely useful if the game expanded from this tech demo to a full game
    // As the amount of classes being created would be unvisible to keep as subclasses. 
    // So having an external directory would keep the originals and then the save system
    // would keep the individual Pokemon the player has due to them potentially being different
    // to the original template.
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
        additionalID.SetCurrentSize(monsterSize.tiny);
        coreStats.SetAC(13);
        coreStats.SetAllStats(11,15,10,6,10,12);
        coreStats.SetMaxHP(16);
        coreStats.SetCurrentHP(coreStats.GetMaxHP());
        coreStats.SetSavingThrowPer(movePower.dexterity);
        coreStats.SetSpeed(30);
        level.SetCurrentLevel(1);
        level.SetMinimumLevel(1);
        moveSet.SetAllMoves("Tackle", "Growl", "Work Up", "Thunder Shock");
        mainType.SetPokemonType(PokemonTypes.electric);
        subType.SetPokemonType(PokemonTypes.typeless);
        typeDefences.AddResistence(PokemonTypes.electric);
        typeDefences.AddResistence(PokemonTypes.flying);
        typeDefences.AddResistence(PokemonTypes.steel);
        typeDefences.AddWeakness(PokemonTypes.ground);
        // This wasn't working and that was due to me not using the correct way of loading Resources
        // Using Unity's Documentation, its just the file name and using the "as Texture2D"
        // So it knows what kind it needs to be.
        // Below is Original.
        //SetFrontView((Texture2D)Resources.Load("Assets/Sprites/pikachu_front.png"));
        //SetRearView((Texture2D)Resources.Load("Assets/Sprites/pikachu_rear.png"));
        // New Updated.
        SetRearString("Sprites/pikachu_back");
        SetFrontString("Sprites/pikachu_front");

    }
}
