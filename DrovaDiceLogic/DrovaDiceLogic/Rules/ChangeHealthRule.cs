using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.Rules
{
    public class ChangeHealthRule : ActionRule
    {
        private int _changeHealth = 0;
        public int ChangeHealth => _changeHealth;

        public ChangeHealthRule(ActionTarget actionTarget, int changeHealth) : base(actionTarget)
        {
            _changeHealth = changeHealth;
        }

        internal override void PlayActionRule(DiceGame game)
        {
            if (ActionTarget == ActionTarget.Enemy)
            {
                foreach (var enemyPlayer in game.CurrentBoard.EnemyPlayers)
                {
                    enemyPlayer.PlayerStats.ChangeHealth(_changeHealth);
                }
            }
            else
            {
                game.CurrentBoard.CurrentPlayer.PlayerStats.ChangeHealth(_changeHealth);
            }
        }
    }
}
