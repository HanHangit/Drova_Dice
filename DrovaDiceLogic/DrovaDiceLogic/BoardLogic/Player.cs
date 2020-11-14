using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.BoardLogic
{
    public class Player
    {
        private PlayerSettings _playerSettings = null;
        public PlayerSettings PlayerSettings => _playerSettings;
        private PlayerStats _playerStats = null;
        public PlayerStats PlayerStats => _playerStats;

        internal Player(PlayerSettings settings, PlayerStats stats)
        {
            _playerStats = stats;
            _playerSettings = settings;
        }


    }
}
