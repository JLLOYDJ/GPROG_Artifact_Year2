using UnityEngine;

public class ModifierArray
{
    private int[] _modifierArray = new int[30];
    public ModifierArray()
    {
        _modifierArray[0] = -5;
        _modifierArray[1] = -4;
        _modifierArray[2] = -4;
        _modifierArray[3] = -3;
        _modifierArray[4] = -3;
        _modifierArray[5] = -2;
        _modifierArray[6] = -2;
        _modifierArray[7] = -1;
        _modifierArray[8] = -1;
        _modifierArray[9] = 0;
        _modifierArray[10] = 0;
        _modifierArray[11] = 1;
        _modifierArray[12] = 1;
        _modifierArray[13] = 2;
        _modifierArray[14] = 2;
        _modifierArray[15] = 3;
        _modifierArray[16] = 3;
        _modifierArray[17] = 4;
        _modifierArray[18] = 4;
        _modifierArray[19] = 5;
        _modifierArray[20] = 5;
        _modifierArray[21] = 6;
        _modifierArray[22] = 6;
        _modifierArray[23] = 7;
        _modifierArray[24] = 7;
        _modifierArray[25] = 8;
        _modifierArray[26] = 8;
        _modifierArray[27] = 9;
        _modifierArray[28] = 9;
        _modifierArray[29] = 10;
    }

    public int ModifierCalulator(byte _movePowerAmount)
    {
        // Went for an array for this as it is better for Index Look-Up
        // Due to it being only 30 (Being fixed), it works out.
        return _modifierArray[_movePowerAmount];

    }
}
