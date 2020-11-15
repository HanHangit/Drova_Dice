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
        private List<int> _saveableNumbers = new List<int>();
        public List<int> SaveableNumbers => _saveableNumbers;

        public readonly Random RandomGenerator = new Random(Guid.NewGuid().GetHashCode());

        public DiceSettings(int minNumber, int maxNumber, List<int> saveableNumbers)
        {
            _minNumber = minNumber;
            _maxNumber = maxNumber;
            _saveableNumbers = saveableNumbers;
        }

        public int RollNewNumber()
        {
            return RandomGenerator.Next(_minNumber, _maxNumber + 1);
        }
    }
}
