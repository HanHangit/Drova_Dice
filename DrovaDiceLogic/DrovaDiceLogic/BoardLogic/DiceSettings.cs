using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.BoardLogic
{
    public class DiceSettings
    {
        private int _minNumber = 1;
        public int MinNumber => _minNumber;
        private int _maxNumber = 6;
        public int MaxNumber => _maxNumber;

        public readonly Random RandomGenerator = new Random(Guid.NewGuid().GetHashCode());

        public DiceSettings(int minNumber, int maxNumber)
        {
            _minNumber = minNumber;
            _maxNumber = maxNumber;
        }

        public int RollNewNumber()
        {
            return RandomGenerator.Next(_minNumber, _maxNumber);
        }
    }
}
