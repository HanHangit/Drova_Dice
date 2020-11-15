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

        public ShootRule(int changeHealth, int amountShoots, int arrowsPerShoot)
        {
            _changeHealth = changeHealth;
            _amountShoots = amountShoots;
            _arrowsPerShoot = arrowsPerShoot;
        }

        internal override void PlayActionRule(DiceGame game, Player target)
        {
            var targetPlayer = target;
            var enemy = game.CurrentBoard.Players.Find(p => p.PlayerStats.ID != target.PlayerStats.ID);
            for (int i = 0; i < _amountShoots; i++)
            {
                if (targetPlayer.PlayerStats.Ammo - _arrowsPerShoot >= 0)
                {
                    enemy.PlayerStats.ChangeHealth(_changeHealth);
                    targetPlayer.PlayerStats.ChangeAmmo(_arrowsPerShoot);
                }
            }
        }
    }
}
