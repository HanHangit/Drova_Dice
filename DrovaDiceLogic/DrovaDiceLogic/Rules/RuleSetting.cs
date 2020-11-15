using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace DrovaDiceLogic.Rules
{
    public class RuleSettings
    {
        private List<Rule> _rules = new List<Rule>();

        public RuleSettings(List<Rule> rules)
        {
            _rules = rules;
        }

        public List<Rule> Rules => _rules;

        public List<Rule> GetInstantRules()
        {
            return _rules.FindAll(r => r.IsInstant);
        }
    }
}
