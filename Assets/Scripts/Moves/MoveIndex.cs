using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This Class contains the Dictonary of all Moves within the Game
/// for easy access in setting up moves for different pokemon.
/// </summary>
public class MoveIndex
{
    // Reason for it not working is due to not being in an function/Awake
    // The issue with the way I originally done this dictonary is it links the moves between the two pokemon
    // This in turn causes both PP and other stuff to be shared, not duplicated.
    // 
    private Dictionary<string, BaseMove> MoveDictionary = new Dictionary<string, BaseMove>();
    // Using a Traditional Constructor as it will be ready when the game is ready.
    public MoveIndex()
    {
        MoveDictionary.Add("Struggle", new Struggle());
        MoveDictionary.Add("Tackle", new Tackle());
        MoveDictionary.Add("Growl", new Growl());
        MoveDictionary.Add("Work Up", new WorkUp());
        MoveDictionary.Add("Thunder Shock", new Thundershock());
        MoveDictionary.Add("Bullet Punch", new BulletPunch());
    }
    
    public BaseMove IDMoveReturn(string moveName)
    {
        bool isValid = MoveDictionary.ContainsKey(moveName);
        if (isValid)
        {
            BaseMove NewMove;
            MoveDictionary.TryGetValue(moveName, out NewMove);
            return NewMove;
        }
        else
        {
            return new Struggle();
        }
    }
}
