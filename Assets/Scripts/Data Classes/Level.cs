using UnityEngine;

public class Level
{
    private byte _minimumLevel = 1;
    public static byte maximumLevel = 20;
    private byte _currentLevel = 1;

    public byte GetMinimumLevel()
    {
        return _minimumLevel;
    }

    public void SetMinimumLevel(byte newMinimum)
    {
        _minimumLevel = newMinimum;
    }

    public byte GetCurrentLevel()
    {
        return _currentLevel;
    }

    public void SetCurrentLevel(byte newCurrent)
    {
        _currentLevel = newCurrent;
    }

    // Originally had the maximumlevel as a private static, but due to its use,
    // I made it a public static variable so it isn't repeated in multiple locations and can be used.
}
