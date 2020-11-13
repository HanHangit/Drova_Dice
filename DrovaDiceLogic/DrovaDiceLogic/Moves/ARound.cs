using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic
{
    public abstract class ARound
    {
        public List<AAction> GetPossibleActions()
        {
            return new List<AAction>();
        }
    }
}
