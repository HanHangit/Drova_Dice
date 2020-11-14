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

        public RoundStartSettings(int numDices, int numPlayers)
        {
            _numDices = numDices;
            _numPlayers = numPlayers;
        }
    }
}
