using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.BoardLogic
{
    public class PlayerStats
    {
        private int _health = 0;
        public int Health => _health;
        private int _ammo = 0;
        public int Ammo => _ammo;

        public delegate void PlayerHealthChangedDelegate(int oldHealth, int newHealth);
        public delegate void PlayerAmmoChangedDelegate(int oldAmmo, int newAmmo);

        public event PlayerHealthChangedDelegate PlayerHealthChangedEvent;
        public event PlayerAmmoChangedDelegate PlayerAmmoChangedEvent;

        internal void ChangeHealth(int health)
        {
            int oldHealth = _health;
            _health += health;

            PlayerHealthChangedEvent?.Invoke(oldHealth, _health);
        }

        internal void ChangeAmmo(int ammo)
        {
            int oldAmmo = _ammo;
            _ammo += ammo;

            PlayerAmmoChangedEvent?.Invoke(oldAmmo, _ammo);
        }
    }
}
