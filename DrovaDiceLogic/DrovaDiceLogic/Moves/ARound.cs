using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.Moves;

namespace DrovaDiceLogic
{
    public abstract class ARound : AGameMove
    {
        public List<AAction> GetPossibleActions()
        {
            return new List<AAction>();
        }
    }
}
