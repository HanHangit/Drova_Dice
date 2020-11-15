using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.BoardLogic;

namespace DrovaDiceLogic.Rules
{
    public abstract class ActionRule
    {
        private ActionTarget _actionTarget = ActionTarget.Self;
        public ActionTarget ActionTarget => _actionTarget;

        protected ActionRule(ActionTarget actionTarget)
        {
            _actionTarget = actionTarget;
        }

        internal abstract void PlayActionRule(DiceGame game, Player target);
    }
}
