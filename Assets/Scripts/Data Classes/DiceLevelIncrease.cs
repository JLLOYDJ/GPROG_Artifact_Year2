using UnityEngine;
/// <summary>
/// Used for adding damage or healing dice that changes as levels increase.
/// </summary>
public class DiceLevelIncrease
{
    private byte[,] _diceLevelIncrease = new byte[Level.maximumLevel, 2];
    // This section handles the dice system that was originally multiple variables.
    public byte GetDiceAmount(byte currentLevel)
    {
        return _diceLevelIncrease[(currentLevel-1), 0];
    }
    public byte GetDiceSize(byte currentLevel)
    {
        return _diceLevelIncrease[(currentLevel-1), 1];
    }
    // This is the setting process, which requires a bit more than the original getters and setters.
    // Might adjust this later.
    /// <summary>
    /// This function takes the Amount of Dice + Dice Size
    /// and places it within the array with it's preset bands following the Poke 5e system.
    /// </summary>
    /// <param name="diceAmount"> The New Amount of Dice being Rolled</param>
    /// <param name="diceSize"> The New Size of Dice being Rolled</param>
    /// <param name="bandNumber"> Band 1: LV01-04, Band 2: LV05-09, Band 3: LV10-14, Band 4: LV15-20</param>
    public void SetLevelDice(byte diceAmount, byte diceSize, byte bandNumber)
    {
        byte minimumLevel;
        byte maximumLevel;
        switch (bandNumber)
        {
            case (1):
                minimumLevel = 1;
                maximumLevel = 4;
                break;
            case (2):
                minimumLevel = 5;
                maximumLevel = 9;
                break;
            case (3):
                minimumLevel = 10;
                maximumLevel = 16;
                break;
            case (4):
                minimumLevel = 17;
                maximumLevel = 20;
                break;
            default:
                Debug.Log("Outside Band Amount");
                return;
        }

        for (int i = (minimumLevel-1); i < maximumLevel; i++)
        {
            _diceLevelIncrease[i, 0] = diceAmount;
            _diceLevelIncrease[i, 1] = diceSize;
        }
    }
    /// <summary>
    /// This is the big function to set all the amounts in 1 go 
    /// using the "SetLevelDice" function multiple times allowing for easier implementation
    /// of moves in initialisation.
    /// </summary>
    /// <param name="diceAmountB1">Band 1 (LV 01-04) Dice Amount</param>
    /// <param name="diceSizeB1">Band 1 (LV 01-04) Dice Size</param>
    /// <param name="diceAmountB2">Band 2 (LV 05-09) Dice Amount</param>
    /// <param name="diceSizeB2">Band 2 (LV 05-09) Dice Size</param>
    /// <param name="diceAmountB3">Band 3 (LV 10-16) Dice Amount</param>
    /// <param name="diceSizeB3">Band 3 (LV 10-16) Dice Size</param>
    /// <param name="diceAmountB4">Band 4 (LV 17-20) Dice Amount</param>
    /// <param name="diceSizeB4">Band 4 (LV 17-20) Dice Size</param>
    public void SetAllLevelDice(byte diceAmountB1, byte diceSizeB1, byte diceAmountB2, byte diceSizeB2, byte diceAmountB3, byte diceSizeB3, byte diceAmountB4, byte diceSizeB4)
    {
        SetLevelDice(diceAmountB1, diceSizeB1, 1);
        SetLevelDice(diceAmountB2, diceSizeB2, 2);
        SetLevelDice(diceAmountB3, diceSizeB3, 3);
        SetLevelDice(diceAmountB4, diceSizeB4, 4);
    }

}
