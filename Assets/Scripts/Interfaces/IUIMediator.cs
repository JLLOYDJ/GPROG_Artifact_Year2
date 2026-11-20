using UnityEngine;

public interface IUIMediator
{
    void Initialisation();
    void PlayerTurn();
    void OpponentTurn();
    void TextDescriptionUpdate(uint moveIndex);
    void MoveActivated();
    void HPUpdate();
    void AttackUpdate(string desc);
    void GameEnding(bool _playerLose);
}
