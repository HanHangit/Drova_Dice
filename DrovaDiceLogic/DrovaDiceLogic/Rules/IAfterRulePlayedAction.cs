using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.BoardLogic;

namespace DrovaDiceLogic.Rules
{
    internal interface IAfterRulePlayedAction
    {
        void PlayAfterRuleAction(DiceGame game, Player target);
    }
}
