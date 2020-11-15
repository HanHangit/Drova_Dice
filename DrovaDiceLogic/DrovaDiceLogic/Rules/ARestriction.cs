using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.Moves;

namespace DrovaDiceLogic.Rules
{
    public abstract class ARestriction
    {
        public abstract bool CheckGameTurn(DiceGame game);
    }
}
