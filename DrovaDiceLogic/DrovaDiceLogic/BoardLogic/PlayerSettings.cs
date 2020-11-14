using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.BoardLogic
{
    public class PlayerSettings
    {
        private int _maxHealth = 0;
        public int MaxHealth => _maxHealth;
        private int _maxAmmo = 0;
        public int MaxAmmo => _maxAmmo;

        public PlayerSettings(int maxHealth, int maxAmmo)
        {
            _maxHealth = maxHealth;
            _maxAmmo = maxAmmo;
        }
    }
}
