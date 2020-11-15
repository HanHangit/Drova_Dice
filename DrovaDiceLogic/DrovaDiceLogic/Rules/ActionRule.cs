using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.BoardLogic;

namespace DrovaDiceLogic.Rules
{
    public abstract class ActionRule
    {
        internal abstract void PlayActionRule(DiceGame game, Player target);
    }
}
