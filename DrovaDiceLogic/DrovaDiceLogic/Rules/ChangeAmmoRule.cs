using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.BoardLogic;

namespace DrovaDiceLogic.Rules
{
    public class ChangeAmmoRule : ActionRule
    {
        private int _changeAmmo = 0;
        public int ChangeAmmo => _changeAmmo;

        public ChangeAmmoRule(int changeAmmo, ActionTarget target = ActionTarget.Target) : base(target)
        {
            _changeAmmo = changeAmmo;
        }

        internal override void PlayActionRule(DiceGame game, Player target)
        {
            if (ActionTarget == ActionTarget.Target)
            {
                target.PlayerStats.ChangeAmmo(_changeAmmo, this);
            }
            else
            {
                game.CurrentBoard.GetOtherPlayer(target).PlayerStats.ChangeAmmo(_changeAmmo, this);
            }
        }
    }
}
