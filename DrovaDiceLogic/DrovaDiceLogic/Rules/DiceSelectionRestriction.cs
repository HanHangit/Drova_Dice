using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.Moves;

namespace DrovaDiceLogic.Rules
{
    public class DiceSelectionRestriction : ARestriction, IAfterRulePlayedAction
    {
        private List<Dice> _neededDices = new List<Dice>();
        public List<Dice> NeededDices => _neededDices;

        internal DiceSelectionRestriction(List<Dice> ruleDices)
        {
            _neededDices = ruleDices;
        }

        public override bool CheckGameTurn(DiceGame game, Player target)
        {
            return IsPossible(game);
        }

        private bool IsPossible(DiceGame game)
        {
            bool result = true;
            var dices = game.CurrentBoard.GetSelectedDices();

            foreach (var dice in _neededDices)
            {
                var foundDice = dices.Find(d => d.Number == dice.Number);
                if (foundDice == null)
                {
                    result = false;
                    break;
                }
                else
                {
                    dices.Remove(foundDice);
                }
            }

            return result && !dices.Any();
        }

        public void PlayAfterRuleAction(DiceGame game, Player target)
        {
            var dices = game.CurrentBoard.GetSelectedDices();

            foreach (var dice in _neededDices)
            {
                var foundDice = dices.Find(d => d.Number == dice.Number);
                dices.Remove(foundDice);
                var currentDice = game.CurrentBoard.GetDice(foundDice.Id);
                currentDice.AddModifier(DiceModifier.Used);
                currentDice.RemoveModifier(DiceModifier.Selected);
                currentDice.RemoveModifier(DiceModifier.Saved);
                currentDice.RemoveModifier(DiceModifier.CanBeRerolled);
            }
        }
    }
}
