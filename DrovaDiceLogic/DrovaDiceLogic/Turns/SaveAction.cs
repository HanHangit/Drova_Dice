using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrovaDiceLogic.BoardLogic;

namespace DrovaDiceLogic.Moves
{
    public class SaveAction : AAction
    {
        public SaveAction()
        {

        }

        private bool CanDiceBeSaved(Dice dice, DiceGame game)
        {
            return dice.HasModifier(DiceModifier.Selected)
                   && !dice.HasModifier(DiceModifier.Saved)
                   && !dice.HasModifier(DiceModifier.Used)
                   && game.DiceGameSettings.DiceSettings.SaveableNumbers.Any(d => d == dice.Number);
        }

        internal override bool ValidateGameAction(DiceGame game)
        {
            var board = game.CurrentBoard;

            if (board.Dices.Any(d => CanDiceBeSaved(d, game)))
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
                foreach (var dice in game.CurrentBoard.Dices.FindAll(d => CanDiceBeSaved(d, game)))
                {
                    game.CurrentBoard.GetDice(dice.Id).AddModifier(DiceModifier.Saved);
                    game.CurrentBoard.GetDice(dice.Id).RemoveModifier(DiceModifier.CanBeRerolled);
                    game.CurrentBoard.GetDice(dice.Id).RemoveModifier(DiceModifier.Selected);
                }
            }
        }
    }
}
