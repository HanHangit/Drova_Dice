using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.BoardLogic;

namespace DrovaDiceLogic.Moves
{
    public class SaveAction : AAction
    {
        public SaveAction(Dice dice) : base(dice)
        {

        }

        internal override bool ValidateGameAction(DiceGame game)
        {
            var board = game.CurrentBoard;
            var dice = board.GetDice(Dice.Id);

            if (!dice.HasModifier(DiceModifier.Saved))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal override void PlayGameAction(DiceGame game)
        {
            if (ValidateGameAction(game))
            {
                var board = game.CurrentBoard;
                var dice = board.GetDice(Dice.Id);

                dice.AddModifier(DiceModifier.Saved);
                dice.RemoveModifier(DiceModifier.CanBeRerolled);
            }
        }
    }
}
