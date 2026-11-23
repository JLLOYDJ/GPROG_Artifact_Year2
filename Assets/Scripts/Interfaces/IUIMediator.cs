using UnityEngine;

public interface IUIMediator
{
    void Initialisation();
    void PlayerTurn();
    void OpponentTurn();
    void TextDescriptionUpdate(uint moveIndex);
    void HPUpdate();
    void AttackUpdate(string desc, bool isEnd);
    void GameEnding(bool _playerLose);
}
