using UnityEngine;

public interface IMove
{
    void Activate();
    void PPCheck(byte PPcurrent, byte PPmax);
    void PPFail();
}
