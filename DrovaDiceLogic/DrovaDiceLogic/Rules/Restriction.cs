using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.Moves;

namespace DrovaDiceLogic.Rules
{
    public class Restriction
    {
        private List<Dice> _neededDices = new List<Dice>();
        public List<Dice> NeededDices => _neededDices;

        internal Restriction(List<Dice> ruleDices)
        {
            _neededDices = ruleDices;
        }

        public bool CheckGameTurn(DiceGame game)
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
    }
}
