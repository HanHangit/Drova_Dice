using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.Rules
{
    public abstract class ActionRule
    {
        private ActionTarget _actionTarget = ActionTarget.Enemy;
        public ActionTarget ActionTarget => _actionTarget;

        internal ActionRule(ActionTarget actionTarget)
        {
            _actionTarget = actionTarget;
        }

        internal abstract void PlayActionRule(DiceGame game);
    }
}
