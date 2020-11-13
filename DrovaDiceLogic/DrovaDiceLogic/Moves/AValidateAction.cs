using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.Moves
{
    public abstract class AGameMove
    {
        internal abstract bool ValidateGameAction(DiceGame game);
        internal abstract void PlayGameAction(DiceGame game);
    }
}
