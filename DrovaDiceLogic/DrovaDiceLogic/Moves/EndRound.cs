using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic
{
    public class EndRound : ARound
    {
        internal override bool ValidateGameAction(DiceGame game)
        {
            return true;
        }

        internal override void PlayGameAction(DiceGame game)
        {
            throw new NotImplementedException();
        }
    }
}
