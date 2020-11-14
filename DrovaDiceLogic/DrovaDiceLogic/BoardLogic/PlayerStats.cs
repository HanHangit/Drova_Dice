using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.BoardLogic
{
    public class PlayerStats
    {
        private int _id = 0;
        public int ID => _id;
        private int _health = 0;
        public int Health => _health;
        private int _ammo = 0;
        public int Ammo => _ammo;
        private int _maxHealth = 0;
        public int MaxHealth => _maxHealth;
        private int _maxAmmo = 0;
        public int MaxAmmo => _maxAmmo;

        public delegate void PlayerHealthChangedDelegate(int oldHealth, int newHealth);
        public delegate void PlayerAmmoChangedDelegate(int oldAmmo, int newAmmo);

        public event PlayerHealthChangedDelegate PlayerHealthChangedEvent;
        public event PlayerAmmoChangedDelegate PlayerAmmoChangedEvent;

        internal PlayerStats(int id, int startHealth, int startAmmo, DiceGameSettings.DiceGameSettings settings)
        {
            _maxHealth = settings.PlayerPlayerSettings.MaxHealth;
            _maxAmmo = settings.PlayerPlayerSettings.MaxAmmo;
            _id = id;
            _health = startHealth;
            _ammo = startAmmo;
        }

        internal void ChangeHealth(int health)
        {
            int oldHealth = _health;
            _health += health;
            _health = Math.Min(_health, _maxHealth);

            PlayerHealthChangedEvent?.Invoke(oldHealth, _health);
        }

        internal void ChangeAmmo(int ammo)
        {
            int oldAmmo = _ammo;
            _ammo += ammo;
            _ammo = Math.Min(_ammo, _maxAmmo);

            PlayerAmmoChangedEvent?.Invoke(oldAmmo, _ammo);
        }
    }
}
