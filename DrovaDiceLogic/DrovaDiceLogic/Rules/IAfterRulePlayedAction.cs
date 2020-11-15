using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.Rules
{
    internal interface IAfterRulePlayedAction
    {
        void PlayAfterRuleAction(DiceGame game);
    }
}
