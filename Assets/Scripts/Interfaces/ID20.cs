using UnityEngine;

public interface ID20
{
    /// <summary>
    /// Takes the Modifer, Buff/Debuff and checks if advantage is currently happening.
    /// Returning a Number with all combined.
    /// </summary>
    /// <param name="_Modifier"></param>
    /// <param name="_Buff"></param>
    /// <param name="_Advantage"></param>
    byte D20Roll(int _Modifier, int _Buff, byte _Advantage, out byte _originalResult);
}