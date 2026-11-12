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
    private Dictionary<uint, BaseMove> MoveDictionary = new Dictionary<uint, BaseMove>();
    // Using a Traditional Constructor as it will be ready when the game is ready.
    public MoveIndex()
    {
        MoveDictionary.Add(0, new Struggle());
        MoveDictionary.Add(1, new Tackle());
        MoveDictionary.Add(2, new Growl());
        MoveDictionary.Add(3, new WorkUp());
        MoveDictionary.Add(4, new Thundershock());
        MoveDictionary.Add(5, new BulletPunch());
    }
    
    public BaseMove IDMoveReturn(uint idNumber)
    {
        bool isValid = MoveDictionary.ContainsKey(idNumber);
        if (isValid)
        {
            Debug.Log("Move Found");
            BaseMove NewMove;
            bool testing = MoveDictionary.TryGetValue(idNumber, out NewMove);
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
