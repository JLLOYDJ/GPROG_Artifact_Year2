using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class BasePokemon : ID20, ISaveThrow // Put interfaces in later or look to doing it inside the manager
{
    public ID coreID = new ID();
    public IDAdditional additionalID = new IDAdditional();
    public CoreMonsterStats coreStats = new CoreMonsterStats();
    public Level level = new Level();
    public CoreMoves moveSet = new CoreMoves();
    public CoreTypeStats mainType = new CoreTypeStats();
    public CoreTypeStats subType = new CoreTypeStats();
    // Have Modifiers here for buffs and debuffs maybe.
    public BuffDebuff buffDebuff = new BuffDebuff();
    // For the Action and Bonus Action
    public ActionBonusAction actionResources = new ActionBonusAction();

    // private Modifier Array so it cannot be altered during gameplay. (Made into Data Class)
    public ModifierArray modifierArray = new ModifierArray();
    public ProficiencyBonus proficiencyBonus = new ProficiencyBonus();
    public TypeDefences typeDefences = new TypeDefences();
    private String _rearViewString;
    private String _frontViewString;
    public String GetRearString()
    {
        return _rearViewString;
    }
    public String GetFrontString()
    {
        return _frontViewString;
    }
    public void SetRearString(string newPath)
    {
        _rearViewString = newPath;
    }
    public void SetFrontString(string newPath)
    {
        _frontViewString = newPath;
    }

    public byte D20Roll(int _modifier, int _buff, byte _advantage, out byte _originalRoll)
    {
        int result;
        // This rolls between 1 and 20 for the dice roll. 
        if (_advantage == Convert.ToByte(DiceAdvantage.advantage))
        {
            int d20_1 = UnityEngine.Random.Range(1, 21);
            int d20_2 = UnityEngine.Random.Range(1, 21);
            if (d20_1 > d20_2)
            {
                result = d20_1;
                _originalRoll = Convert.ToByte(d20_1);
            }
            else
            {
                result = d20_2;
                _originalRoll = Convert.ToByte(d20_2);
            }
        }
        else if (_advantage == Convert.ToByte(DiceAdvantage.disadvantage))
        {
            int d20_1 = UnityEngine.Random.Range(1, 21);
            int d20_2 = UnityEngine.Random.Range(1, 21);
            if (d20_1 > d20_2)
            {
                result = d20_2;
                _originalRoll = Convert.ToByte(d20_2);
            }
            else
            {
                result = d20_1;
                _originalRoll = Convert.ToByte(d20_1);
            }
        }
        else
        {
            result = UnityEngine.Random.Range(1, 21);
            _originalRoll = Convert.ToByte(result);
        }

        result += _modifier;
        result += _buff;

        return Convert.ToByte(result);
        
    }
    // Finish this one off Friday.
    public byte SavingThrowCal(int _Modifier, int _buff, byte _proBonus)
    {
        byte result = Convert.ToByte(8 + _Modifier + _buff + _proBonus);
        return result;
    }
}
