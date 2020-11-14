using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.DiceGameSettings;

namespace DrovaDiceLogic
{
    public class DiceSettingsObject
    {
        private DiceGameSettings.DiceGameSettings _gameSettings = null;
        public DiceGameSettings.DiceGameSettings GameSettings => _gameSettings;

        internal DiceSettingsObject(DiceGameSettings.DiceGameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }
    }
}
