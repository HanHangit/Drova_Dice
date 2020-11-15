using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.BoardLogic;

namespace DrovaDiceLogic.Rules
{
    public class PatzerRule : ActionRule, IInstantRule
    {
        private int _changeAmmo = 0;
        public int ChangeAmmo => _changeAmmo;
        private int _changeHealth = 0;
        public int ChangeHealth => _changeHealth;

        public PatzerRule(int changeAmmo, int changeHealth, ActionTarget target = ActionTarget.Target) : base(target)
        {
            _changeAmmo = changeAmmo;
            _changeHealth = changeHealth;
        }

        internal override void PlayActionRule(DiceGame game, Player target)
        {
            foreach (var player in game.CurrentBoard.Players)
            {
                if (player.PlayerStats.Ammo - _changeAmmo < 0)
                {
                    player.PlayerStats.ChangeHealth(_changeHealth);
                }
                else
                {
                    player.PlayerStats.ChangeAmmo(_changeAmmo);
                }
            }
        }
    }
}
