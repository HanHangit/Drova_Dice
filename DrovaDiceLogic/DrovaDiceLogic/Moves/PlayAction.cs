using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrovaDiceLogic.BoardLogic;

namespace DrovaDiceLogic.Moves
{
    public class PlayAction : AAction
    {
        public PlayAction() : base(null)
        {

        }

        internal override bool ValidateGameAction(DiceGame game)
        {
            return game.CurrentBoard.Dices.Any(d => d.HasModifier(DiceModifier.Selected));
        }

        internal override void PlayGameAction(DiceGame game)
        {
            if (ValidateGameAction(game))
            {
                game.CurrentBoard.CurrentPlayer.PlayerStats.ChangeAmmo(-1);
                foreach (var otherPlayer in game.CurrentBoard.Players)
                {
                    if (otherPlayer.PlayerStats.ID != game.CurrentBoard.CurrentPlayer.PlayerStats.ID)
                    {
                        otherPlayer.PlayerStats.ChangeHealth(-1);
                    }
                }
            }
        }
    }
}
