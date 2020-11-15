using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.Rules
{
    public class PatzerRule : ActionRule, IInstantRule
    {
        private int _changeAmmo = 0;
        public int ChangeAmmo => _changeAmmo;
        private int _changeHealth = 0;
        public int ChangeHealth => _changeHealth;

        public PatzerRule(ActionTarget actionTarget, int changeAmmo, int changeHealth) : base(actionTarget)
        {
            _changeAmmo = changeAmmo;
            _changeHealth = changeHealth;
        }

        internal override void PlayActionRule(DiceGame game)
        {
            var currentPlayer = game.CurrentBoard.CurrentPlayer;
            if (currentPlayer.PlayerStats.Ammo - _changeAmmo < 0)
            {
                currentPlayer.PlayerStats.ChangeHealth(_changeHealth);
            }
            else
            {
                currentPlayer.PlayerStats.ChangeAmmo(_changeAmmo);
            }
        }
    }
}
