using System;
using System.Collections.Generic;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.DiceGameSettings;

namespace DrovaDiceLogic
{
    public class DiceGame
    {
        private ARound _currentRound = null;
        public ARound CurrentRound => _currentRound;
        private DiceGameSettings.DiceGameSettings _diceGameSettings = null;
        public DiceGameSettings.DiceGameSettings DiceGameSettings => _diceGameSettings;
        private Board _currentBoard = new Board();
        internal Board CurrentBoard => _currentBoard;

        public DiceGame(DiceGameSettings.DiceGameSettings gameSettings)
        {
            Init(gameSettings);
        }

        public void Init(DiceGameSettings.DiceGameSettings gameSettings)
        {
            _diceGameSettings = gameSettings;
            _currentBoard.InitSettings(gameSettings);
        }

        public bool CanBePlayed(ARound round)
        {
            return true;
        }

        public bool CanBePlayed(AMove move)
        {
            return true;
        }

        public bool CanBePlayed(AAction action)
        {
            return action.ValidateGameAction(this);
        }

        public bool Play(AAction action)
        {
            if (action.ValidateGameAction(this))
            {
                action.PlayGameAction(this);
                return true;
            }

            return false;
        }
    }
}
