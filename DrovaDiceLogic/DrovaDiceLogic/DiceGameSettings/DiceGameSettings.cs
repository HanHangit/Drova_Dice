using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.Rules;

namespace DrovaDiceLogic.DiceGameSettings
{
    public class DiceGameSettings
    {
        private RoundStartSettings _startSettings = null;
        public RoundStartSettings StartSettings => _startSettings;
        private DiceSettings _diceSettings = null;
        public DiceSettings DiceSettings => _diceSettings;
        private PlayerSettings _playerPlayerSettings = null;
        public PlayerSettings PlayerPlayerSettings => _playerPlayerSettings;
        private RuleSettings _ruleSettings = null;
        public RuleSettings RuleSettings => _ruleSettings;

        public DiceGameSettings(RoundStartSettings roundStartSettings, DiceSettings diceSettings, PlayerSettings playerSettings, RuleSettings ruleSettings)
        {
            _startSettings = roundStartSettings;
            _diceSettings = diceSettings;
            _playerPlayerSettings = playerSettings;
            _ruleSettings = ruleSettings;
        }

        public static DiceGameSettings CreateDefaultGameSettings()
        {
            return new DiceGameSettings(
                    new RoundStartSettings(6, 2), 
                    new DiceSettings(1, 6), 
                    new PlayerSettings(20, 5),
                    new RuleSettings(new List<ActionRule>
                    {
                    }));
        }
    }
}
