using UnityEngine;

public interface IMove
{
    void Activate(BasePokemon User);
    // Originally had PPMax, but doesn't need that as it is to check if it is above 0, if so, the move can work.
    bool PPCheck();
    void PPFail();
}
