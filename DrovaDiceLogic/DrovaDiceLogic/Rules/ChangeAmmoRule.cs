using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.Rules
{
    public class ChangeAmmoRule : ActionRule
    {
        private int _changeAmmo = 0;
        public int ChangeAmmo => _changeAmmo;

        public ChangeAmmoRule(ActionTarget actionTarget, int changeAmmo, List<Restriction> restrictions) : base(actionTarget, restrictions)
        {
            _changeAmmo = changeAmmo;
        }

        protected override void PlayActionRule(DiceGame game)
        {
            if (ActionTarget == ActionTarget.Enemy)
            {
                foreach (var enemyPlayer in game.CurrentBoard.EnemyPlayers)
                {
                    enemyPlayer.PlayerStats.ChangeAmmo(_changeAmmo);
                }
            }
            else
            {
                game.CurrentBoard.CurrentPlayer.PlayerStats.ChangeAmmo(_changeAmmo);
            }
        }
    }
}
