using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.BoardLogic
{
    public class Dice : ICloneable
    {
        private int _id = 0;
        public int Id => _id;

        private int _number = 0;
        public int Number => _number;

        private DiceSettings _diceSettings = null;

        private HashSet<DiceModifier> _modifiers = new HashSet<DiceModifier>();

        public Dice(int id)
        {
            _id = id;
        }

        internal Dice(int id, int number)
        {
            _number = number;
        }

        internal Dice(int id, int number, DiceSettings settings)
        {
            _id = id;
            _number = number;
            _diceSettings = settings;
            _modifiers.Add(DiceModifier.CanBeRerolled);
        }

        public bool HasModifier(DiceModifier modifier) => _modifiers.Contains(modifier);

        internal void AddModifier(DiceModifier modifier) => _modifiers.Add(modifier);

        internal void RemoveModifier(DiceModifier modifier) => _modifiers.Remove(modifier);

        internal void Reroll()
        {
            _number = _diceSettings.RollNewNumber();
        }

        public object Clone()
        {
            HashSet<DiceModifier> modifiers = new HashSet<DiceModifier>();
            foreach (var diceModifier in _modifiers)
            {
                modifiers.Add(diceModifier);
            }
            return new Dice(_id)
            {
                _number = _number,
                _diceSettings = _diceSettings,
                _modifiers = modifiers
            };
        }
    }
}
