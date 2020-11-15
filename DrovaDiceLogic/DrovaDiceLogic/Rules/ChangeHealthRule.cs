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

        public ChangeHealthRule(int changeHealth)
        {
            _changeHealth = changeHealth;
        }

        internal override void PlayActionRule(DiceGame game, Player target)
        {
            target.PlayerStats.ChangeHealth(_changeHealth);
        }
    }
}
