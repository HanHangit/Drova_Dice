using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.BoardLogic;

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

        public DiceGameSettings(RoundStartSettings roundStartSettings, DiceSettings diceSettings, PlayerSettings playerSettings)
        {
            _startSettings = roundStartSettings;
            _diceSettings = diceSettings;
            _playerPlayerSettings = playerSettings;
        }

        public static DiceGameSettings CreateDefaultGameSettings()
        {
            return new DiceGameSettings(new RoundStartSettings(6, 2), new DiceSettings(1, 6), new PlayerSettings(20, 5));
        }
    }
}
