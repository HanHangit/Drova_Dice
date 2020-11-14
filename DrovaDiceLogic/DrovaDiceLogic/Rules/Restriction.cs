﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.Moves;

namespace DrovaDiceLogic.Rules
{
    internal class Restriction
    {
        private List<Dice> _neededDices = new List<Dice>();

        internal bool CheckGameTurn(DiceGame game, SelectAction gameTurn)
        {
            if (!IsPossible(game))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsPossible(DiceGame game)
        {
            bool result = true;
            var dices = game.CurrentBoard.Dices;

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

            return result;
        }
    }
}