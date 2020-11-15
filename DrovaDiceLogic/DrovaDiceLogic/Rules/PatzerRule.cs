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

        public PatzerRule(int changeAmmo, int changeHealth)
        {
            _changeAmmo = changeAmmo;
            _changeHealth = changeHealth;
        }

        internal override void PlayActionRule(DiceGame game, Player target)
        {
            var currentPlayer = target;
            if (currentPlayer.PlayerStats.Ammo - _changeAmmo < 0)
            {
                target.PlayerStats.ChangeHealth(_changeHealth);
            }
            else
            {
                currentPlayer.PlayerStats.ChangeAmmo(_changeAmmo);
            }
        }
    }
}
