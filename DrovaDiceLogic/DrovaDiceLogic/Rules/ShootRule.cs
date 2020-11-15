using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.BoardLogic;

namespace DrovaDiceLogic.Rules
{
    public class ShootRule : ActionRule
    {
        private int _changeHealth = 0;
        public int ChangeHealth => _changeHealth;
        private int _amountShoots = 0;
        private int _arrowsPerShoot = 0;

        public ShootRule(int changeHealth, int amountShoots, int arrowsPerShoot, ActionTarget actionTarget = ActionTarget.Target) : base(actionTarget)
        {
            _changeHealth = changeHealth;
            _amountShoots = amountShoots;
            _arrowsPerShoot = arrowsPerShoot;
        }

        internal override void PlayActionRule(DiceGame game, Player target)
        {
            var targetPlayer = target;
            var origin = game.CurrentBoard.Players.Find(p => p.PlayerStats.ID != target.PlayerStats.ID);
            for (int i = 0; i < _amountShoots; i++)
            {
                if (origin.PlayerStats.Ammo - _arrowsPerShoot >= 0)
                {
                    targetPlayer.PlayerStats.ChangeHealth(_changeHealth, this);
                    origin.PlayerStats.ChangeAmmo(-_arrowsPerShoot, this);
                }
            }
        }
    }
}
