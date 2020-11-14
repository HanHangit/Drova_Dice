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
        private PlayerSettings _playerSettings = null;
        public PlayerSettings PlayerSettings => _playerSettings;

        public DiceGameSettings(RoundStartSettings roundStartSettings, DiceSettings diceSettings, PlayerSettings settings)
        {
            _startSettings = roundStartSettings;
            _diceSettings = diceSettings;
        }

        public static DiceGameSettings CreateDefaultGameSettings()
        {
            return new DiceGameSettings(new RoundStartSettings(6, 2), new DiceSettings(1, 6), new PlayerSettings(20, 5));
        }
    }
}
