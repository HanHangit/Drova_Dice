using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.Moves;

namespace DrovaDiceLogic
{
    public abstract class ADiceAction : AAction
    {
        private Dice _dice;
        public Dice Dice => _dice;

        protected ADiceAction(Dice dice)
        {
            _dice = dice;
        }
    }
}
