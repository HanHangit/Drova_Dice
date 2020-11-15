using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.Moves;

namespace DrovaDiceLogic
{
    public abstract class AAction : AGameTurn
    {
        private Dice _dice;
        public Dice Dice => _dice;

        protected AAction(Dice dice)
        {
            _dice = dice;
        }
    }
}
