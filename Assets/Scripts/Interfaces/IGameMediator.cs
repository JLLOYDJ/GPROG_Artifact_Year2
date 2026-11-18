using UnityEngine;

public interface IGameMediator
{
    void NotifyOnDamage(BasePokemon Opponent, uint amount);
    void NotifyOnGameOver();
    // Expand with more stuff.
}
