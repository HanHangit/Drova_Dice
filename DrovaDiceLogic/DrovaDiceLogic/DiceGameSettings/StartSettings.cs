using System;
using System.Collections.Generic;
using System.Text;

namespace DrovaDiceLogic.DiceGameSettings
{
    public class RoundStartSettings
    {
        private int _numDices = 6;
        public int NumDices => _numDices;
        private int _numPlayers = 2;
        public int NumPlayers => _numPlayers;
        private int _numRerolls = 2;
        public int NumRerolls => _numRerolls;

        public RoundStartSettings(int numDices, int numPlayers, int numRerolls)
        {
            _numDices = numDices;
            _numPlayers = numPlayers;
            _numRerolls = numRerolls;
        }
    }
}
