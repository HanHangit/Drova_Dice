using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.DiceGameSettings
{
    public class RoundStartSettings
    {
        private int _numDices = 6;
        public int NumDices => _numDices;

        public RoundStartSettings(int numDices)
        {
            _numDices = numDices;
        }
    }
}
