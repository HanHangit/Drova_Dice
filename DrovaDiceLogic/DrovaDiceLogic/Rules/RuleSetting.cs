using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.Rules
{
    public class RuleSettings
    {
        private List<ActionRule> _actionRules = new List<ActionRule>();

        public RuleSettings(List<ActionRule> actionRules)
        {
            _actionRules = actionRules;
        }

        public List<ActionRule> ActionRules => _actionRules;
    }
}
