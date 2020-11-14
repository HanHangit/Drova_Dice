using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrovaDiceLogic.BoardLogic;

namespace DrovaDiceLogic
{
    public class RerollMove : AMove
    {
        internal override bool ValidateGameAction(DiceGame game)
        {
            var board = game.CurrentBoard;

            return board.Dices.Any(d => d.HasModifier(DiceModifier.CanBeRerolled));
        }

        internal override void PlayGameAction(DiceGame game)
        {
            if (ValidateGameAction(game))
            {
                var board = game.CurrentBoard;
                board.RerollDices();
            }
        }
    }
}
