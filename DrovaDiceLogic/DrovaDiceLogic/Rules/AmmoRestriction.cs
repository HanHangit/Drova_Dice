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

        public override bool CheckGameTurn(DiceGame game, Player target)
        {
            var enemy = game.CurrentBoard.Players.Find(p => p.PlayerStats.ID != target.PlayerStats.ID);
            return game.CurrentBoard.GetPlayer(enemy.PlayerStats.ID).PlayerStats.Ammo >= _neededAmmo;
        }
    }
}
