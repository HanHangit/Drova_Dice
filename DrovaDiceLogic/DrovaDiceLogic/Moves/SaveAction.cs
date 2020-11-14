using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrovaDiceLogic.BoardLogic;

namespace DrovaDiceLogic.Moves
{
    public class SaveAction : AAction
    {
        public SaveAction() : base(null)
        {

        }

        internal override bool ValidateGameAction(DiceGame game)
        {
            var board = game.CurrentBoard;

            if (board.Dices.Any(d => (d.HasModifier(DiceModifier.Selected) && !d.HasModifier(DiceModifier.Saved))))
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
                foreach (var dice in game.CurrentBoard.Dices.FindAll(d => d.HasModifier(DiceModifier.Selected) && !d.HasModifier(DiceModifier.Saved)))
                {
                    game.CurrentBoard.GetDice(dice.Id).AddModifier(DiceModifier.Saved);
                    game.CurrentBoard.GetDice(dice.Id).RemoveModifier(DiceModifier.CanBeRerolled);
                    game.CurrentBoard.GetDice(dice.Id).RemoveModifier(DiceModifier.Selected);
                }
            }
        }
    }
}
