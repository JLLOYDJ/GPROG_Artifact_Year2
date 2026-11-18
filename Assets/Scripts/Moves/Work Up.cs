using System;
using UnityEngine;

public class WorkUp : BaseMove
{
    private bool _isActive = false;
    public WorkUp() // Converted from Awake to Constructor so it would compile before runtime.
    {
        moveID.SetName("Work Up");
        moveID.SetDescription("You get your adrenaline pumping and go into a frenzy.\n" +
            "While worked up, you add +2 to all attack rolls.\n" +
            "Your worked up status ends if you are incapacitated\n" +
            "or if your turn ends and you have not attacked a hostile target since your last turn,\n" +
            "or taken any damage since then.");
        moveID.SetUniqueID(3);
        coreStats.SetAction(false);
        coreStats.SetDuration(10);
        coreStats.SetRange(0);
        coreStats.SetTarget(Target.self);
        coreType.SetPokemonType(PokemonTypes.normal);
        // Doesn't need Level Increasing due to being a modifier
        powerPoints.SetPPMax(3);
        powerPoints.SetPPCurrent(powerPoints.GetPPMax());
        SetMovePower(movePower.none);
        SetMoveVariant(moveVariant.Buff);
    }

    public override void Activate(BasePokemon User)
    {
        // Checks if Bonus Action has been used, if not continue
        // checks for PP first and does PPFail if there is nothing
        // Grabs Singleton Manager, passes through player and opponent
        // Add +2 to modifier, if player doesn't attack, it ends.
        // Add timer to buff (Maybe list or Dictonary for keeping track of these).

        bool IsAction = User.actionResources.GetBonusAction();
        if (IsAction)
        {
            bool _isMoveAvailable = PPCheck();
            if (_isMoveAvailable)
            {
                powerPoints.ReducePPCurrent();
                User.actionResources.ActivateBonusAction();
                if (_isActive == false)
                {
                    _isActive = true;
                    User.buffDebuff.NewBuffDebuffAttack(2, coreStats.GetDuration());
                    UIManager.UIInstance.AttackUpdate("Work Up Now Active!");
                }
                else
                {
                    UIManager.UIInstance.AttackUpdate("Work Up Already Active!");
                }
            }
            else
            {
                UIManager.UIInstance.AttackUpdate("No Remaining PP for Workup!");
                return;
            }
        }
        else
        {
            UIManager.UIInstance.AttackUpdate("No Bonus Action Remaining!");
            return;
        }

    }
}
