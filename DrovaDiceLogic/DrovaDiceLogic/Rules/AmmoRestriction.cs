using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.Moves;

namespace DrovaDiceLogic.Rules
{
    public class AmmoRestriction : ARestriction
    {
        private int _neededAmmo = 0;

        internal AmmoRestriction(int neededAmmo)
        {
            _neededAmmo = neededAmmo;
        }

        public override bool CheckGameTurn(DiceGame game)
        {
            return game.CurrentBoard.CurrentPlayer.PlayerStats.Ammo >= _neededAmmo;
        }
    }
}
