using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.Rules
{
    public class ShootRule : ActionRule
    {
        private int _changeHealth = 0;
        public int ChangeHealth => _changeHealth;
        private int _amountShoots = 0;
        private int _arrowsPerShoot = 0;

        public ShootRule(ActionTarget actionTarget, int changeHealth, int amountShoots, int arrowsPerShoot) : base(actionTarget)
        {
            _changeHealth = changeHealth;
            _amountShoots = amountShoots;
            _arrowsPerShoot = arrowsPerShoot;
        }

        internal override void PlayActionRule(DiceGame game)
        {
            if (ActionTarget == ActionTarget.Enemy)
            {
                for (int i = 0; i < _amountShoots; i++)
                {
                    if (game.CurrentBoard.CurrentPlayer.PlayerStats.Ammo - _arrowsPerShoot >= 0)
                    {
                        foreach (var enemyPlayer in game.CurrentBoard.EnemyPlayers)
                        {
                            enemyPlayer.PlayerStats.ChangeHealth(_changeHealth);
                        }
                        game.CurrentBoard.CurrentPlayer.PlayerStats.ChangeAmmo(_arrowsPerShoot);
                    }
                }
            }
            else
            {
                for (int i = 0; i < _amountShoots; i++)
                {
                    if (game.CurrentBoard.CurrentPlayer.PlayerStats.Ammo - _arrowsPerShoot >= 0)
                    {
                        game.CurrentBoard.CurrentPlayer.PlayerStats.ChangeHealth(_changeHealth);
                        game.CurrentBoard.CurrentPlayer.PlayerStats.ChangeAmmo(_arrowsPerShoot);
                    }
                }
            }
        }
    }
}
