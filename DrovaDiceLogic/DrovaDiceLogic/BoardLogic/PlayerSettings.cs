using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.BoardLogic
{
    public class PlayerSettings
    {
        private int _maxHealth = 0;
        public int MaxHealth => _maxHealth;
        private int _startHealth = 0;
        public int StartHealth => _startHealth;
        private int _maxAmmo = 0;
        public int MaxAmmo => _maxAmmo;
        private int _startAmmo = 0;
        public int StartAmmo => _startAmmo;

        public PlayerSettings(int startHealth, int startAmmo, int maxHealth, int maxAmmo)
        {
            _maxHealth = maxHealth;
            _maxAmmo = maxAmmo;
            _startAmmo = startAmmo;
            _startHealth = startHealth;
        }
    }
}
