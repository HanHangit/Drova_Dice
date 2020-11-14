using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.Rules
{
    public abstract class ActionRule
    {
        private ActionTarget _actionTarget = ActionTarget.Enemy;
        public ActionTarget ActionTarget => _actionTarget;
        private List<Restriction> _restrictions = new List<Restriction>();

        internal ActionRule(ActionTarget actionTarget, List<Restriction> restrictions)
        {
            _actionTarget = actionTarget;
            _restrictions = restrictions;
        }

        internal void DoAction(DiceGame game)
        {
            if (IsPossible(game))
            {
                PlayActionRule(game);
            }
        }

        protected abstract void PlayActionRule(DiceGame game);

        public bool IsPossible(DiceGame game)
        {
            bool result = true;

            foreach (var restriction in _restrictions)
            {
                if (!restriction.CheckGameTurn(game))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
