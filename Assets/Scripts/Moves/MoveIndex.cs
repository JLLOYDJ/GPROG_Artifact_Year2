using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This Class contains the Dictonary of all Moves within the Game
/// for easy access in setting up moves for different pokemon.
/// </summary>
public class MoveIndex
{
    // Reason for it not working is due to not being in an function/Awake
    // I love this dictionary!
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
            Debug.Log("Move Found");
            BaseMove NewMove;
            MoveDictionary.TryGetValue(moveName, out NewMove);
            Debug.Log(NewMove.moveID.GetName());
            return NewMove;
        }
        else
        {
            Debug.Log("Invalid ID, Defaulting to Struggle");
            return new Struggle();
        }
    }
}
