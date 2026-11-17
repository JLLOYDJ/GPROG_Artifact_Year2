using System;
using UnityEngine;
[Serializable]
public class ProficiencyBonus
{
    // Hard Coded for this project, but will be adjusted if developed past this.
    private byte _proficiencyBonus = 2;
    public byte GetProficiencyBonus()
    {
        return _proficiencyBonus;
    }
}
