using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.BoardLogic;

namespace DrovaDiceLogic.Rules
{
    public class ChangeHealthRule : ActionRule
    {
        private int _changeHealth = 0;
        public int ChangeHealth => _changeHealth;

        public ChangeHealthRule(int changeHealth, ActionTarget target = ActionTarget.Target) : base(target)
        {
            _changeHealth = changeHealth;
        }

        internal override void PlayActionRule(DiceGame game, Player target)
        {
            if (ActionTarget == ActionTarget.Target)
            {
                target.PlayerStats.ChangeHealth(_changeHealth, this);
            }
            else
            {
                game.CurrentBoard.GetOtherPlayer(target).PlayerStats.ChangeHealth(_changeHealth, this);
            }
        }
    }
}
