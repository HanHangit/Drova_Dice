using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrovaDiceLogic.Rules
{
    public class Rule
    {
        private List<ActionRule> _actionRules = new List<ActionRule>();
        public List<ActionRule> ActionRules => _actionRules;
        private List<ARestriction> _restrictions = new List<ARestriction>();
        public List<ARestriction> Restrictions => _restrictions;

        public Rule(List<ActionRule> actionRules, List<ARestriction> restrictions)
        {
            _actionRules = actionRules;
            _restrictions = restrictions;
        }

        public bool CanPlayRule(DiceGame game)
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

        internal void PlayRule(DiceGame game)
        {
            if (CanPlayRule(game))
            {
                PlayActionRules(game);
                PlayerAfterActions(game);
            }
        }

        private void PlayActionRules(DiceGame game)
        {
            foreach (var actionRule in _actionRules)
            {
                actionRule.PlayActionRule(game);
            }
        }

        private void PlayerAfterActions(DiceGame game)
        {
            foreach (var actionRule in _actionRules)
            {
                if (actionRule is IAfterRulePlayedAction afterRule)
                {
                    afterRule.PlayAfterRuleAction(game);
                }
            }

            foreach (var restriction in _restrictions)
            {
                if (restriction is IAfterRulePlayedAction afterRule)
                {
                    afterRule.PlayAfterRuleAction(game);
                }
            }
        }

        public bool IsInstant => _actionRules.Any(r => r is IInstantRule);
    }
}
