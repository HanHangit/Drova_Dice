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
            throw new NotImplementedException();
        }

        internal override void PlayGameAction(DiceGame game)
        {
            throw new NotImplementedException();
        }
    }
}
