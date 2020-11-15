using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrovaDiceLogic.BoardLogic;

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

        public bool CanPlayRule(DiceGame game, Player target)
        {
            bool result = true;

            foreach (var restriction in _restrictions)
            {
                if (!restriction.CheckGameTurn(game, target))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        internal void PlayRule(DiceGame game, Player target)
        {
            if (CanPlayRule(game, target))
            {
                PlayActionRules(game, target);
                PlayerAfterActions(game, target);
            }
        }

        private void PlayActionRules(DiceGame game, Player target)
        {
            foreach (var actionRule in _actionRules)
            {
                actionRule.PlayActionRule(game, target);
            }
        }

        private void PlayerAfterActions(DiceGame game, Player target)
        {
            foreach (var actionRule in _actionRules)
            {
                if (actionRule is IAfterRulePlayedAction afterRule)
                {
                    afterRule.PlayAfterRuleAction(game, target);
                }
            }

            foreach (var restriction in _restrictions)
            {
                if (restriction is IAfterRulePlayedAction afterRule)
                {
                    afterRule.PlayAfterRuleAction(game, target);
                }
            }
        }

        public bool IsInstant => _actionRules.Any(r => r is IInstantRule);
    }
}
