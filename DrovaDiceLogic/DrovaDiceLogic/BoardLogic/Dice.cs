using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.BoardLogic
{
    public class Dice
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
    }
}
