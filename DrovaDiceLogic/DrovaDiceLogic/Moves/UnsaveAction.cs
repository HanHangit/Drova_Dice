using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.BoardLogic;

namespace DrovaDiceLogic.Moves
{
    public class UnsaveAction : AAction
    {
        public UnsaveAction(Dice dice) : base(dice)
        {

        }

        internal override bool ValidateGameAction(DiceGame game)
        {
            var board = game.CurrentBoard;
            var dice = board.GetDice(Dice.Id);

            if (dice.HasModifier(DiceModifier.Saved))
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

                dice.RemoveModifier(DiceModifier.Saved);
                dice.AddModifier(DiceModifier.CanBeRerolled);
            }
        }
    }
}
