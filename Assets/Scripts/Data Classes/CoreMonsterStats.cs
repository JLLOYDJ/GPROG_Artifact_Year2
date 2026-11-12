using System;
using UnityEngine;

public class CoreMonsterStats : IHeal
{
    private uint _hp;
    private uint _maxHP;
    private uint _speed;
    private byte[] _stats = new byte[6];
    // looking into circular lists, will add when everything else is fleshed out
    private byte _ac;
    private byte _savingThrowPer;

    public uint GetCurrentHP()
    {
        return _hp;
    }
    public void SetCurrentHP(uint newHP)
    {
        _hp = newHP;
    }
    public void HPHeal(uint amount)
    {
        _hp += amount;
    }
    public void HPDamage(uint amount)
    {
        _hp -= amount;
    }
    public uint GetMaxHP()
    {
        return _maxHP;
    }
    public void SetMaxHP(uint newMax)
    {
        _maxHP = newMax;
    }
    public uint GetSpeed()
    {
        return _speed;
    }
    /// <summary>
    /// Speed entered will be modulo by 5, if it isn't a multiple of 5, the new speed will not be added.
    /// </summary>
    /// <param name="newSpeed"></param>
    public void SetSpeed(uint newSpeed)
    {
        if ((newSpeed % 5) == 0)
        {
            _speed = newSpeed;
        }
        else
        {
            Debug.Log("Speed not Multiple of 5.");
        }
    }
    public byte GetIndividualStat(byte movePower)
    {
        return _stats[(movePower - 1)];
    }
    public void SetIndividualStat(byte newStat, byte movePower)
    {
        _stats[(movePower - 1)] = newStat;
    }
    /// <summary>
    /// This takes all the stats needed and sets it though the "SetIndividualStat".
    /// </summary>
    /// <param name="strength"></param>
    /// <param name="dexterity"></param>
    /// <param name="constitution"></param>
    /// <param name="intelligence"></param>
    /// <param name="wisdom"></param>
    /// <param name="charisma"></param>
    public void SetAllStats(byte strength, byte dexterity, byte constitution, byte intelligence, byte wisdom, byte charisma)
    {
        SetIndividualStat(strength, Convert.ToByte(movePower.strength));
        SetIndividualStat(dexterity, Convert.ToByte(movePower.dexterity));
        SetIndividualStat(constitution, Convert.ToByte(movePower.consitution));
        SetIndividualStat(intelligence, Convert.ToByte(movePower.intelligence));
        SetIndividualStat(wisdom, Convert.ToByte(movePower.wisdom));
        SetIndividualStat(charisma, Convert.ToByte(movePower.charisma));
    }
    public byte GetAC()
    {
        return _ac;
    }
    public void SetAC(byte newAC)
    {
        _ac = newAC;
    }
    public byte GetSavingThrowPer()
    {
        return _savingThrowPer;
    }
    public void SetSavingThrowPer(byte newSavingThrowPer)
    {
        if (newSavingThrowPer == 0)
        {
            Debug.Log("Saving Throw Perficiency cannot be Typeless");
        }
        else
        {
            _savingThrowPer = newSavingThrowPer;
        }
    }
}
