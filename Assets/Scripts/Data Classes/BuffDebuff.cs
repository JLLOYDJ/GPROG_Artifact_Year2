using UnityEngine;

public class BuffDebuff
{
    private int _modifiedAmountAttack = 0;
    private uint _amountOfTurnsBuffAttack = 0;
    public int GetCurrentModifiedAttack()
    {
        return _modifiedAmountAttack;
    }
    public uint GetLengthOfModifiedAttack()
    {
        return _amountOfTurnsBuffAttack;
    }
    public void NewBuffDebuffAttack(int amount, uint turns)
    {
        _modifiedAmountAttack += amount;
        _amountOfTurnsBuffAttack = turns;
    }
    public void ResettingModified()
    {
        _modifiedAmountAttack = default;
    }
}
