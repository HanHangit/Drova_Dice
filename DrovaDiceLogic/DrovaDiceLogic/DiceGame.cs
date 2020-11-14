using System;
using System.Collections.Generic;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.DiceGameSettings;
using DrovaDiceLogic.Moves;

namespace DrovaDiceLogic
{
    public class DiceGame
    {
        private ARound _currentRound = null;
        public ARound CurrentRound => _currentRound;
        private DiceGameSettings.DiceGameSettings _diceGameSettings = null;
        public DiceGameSettings.DiceGameSettings DiceGameSettings => _diceGameSettings;
        private Board _currentBoard = new Board();
        public Board CurrentBoard => _currentBoard;

        public delegate void ActionEndedDelegate(GameMoveEndedEventArgs args);

        public event ActionEndedDelegate ActionEndedEvent;

        public DiceGame(DiceGameSettings.DiceGameSettings gameSettings)
        {
            Init(gameSettings);
        }

        public void Init(DiceGameSettings.DiceGameSettings gameSettings)
        {
            _diceGameSettings = gameSettings;
            _currentBoard.InitSettings(gameSettings);
        }

        public bool CanBePlayed(AGameMove action)
        {
            return action.ValidateGameAction(this);
        }

        public bool Play(AGameMove action)
        {
            if (action.ValidateGameAction(this))
            {
                action.PlayGameAction(this);
                ActionEndedEvent?.Invoke(new GameMoveEndedEventArgs(this, action));
                return true;
            }

            return false;
        }

        public struct GameMoveEndedEventArgs
        {
            public DiceGame DiceGame;
            public AGameMove Action;

            public GameMoveEndedEventArgs(DiceGame diceGame, AGameMove action)
            {
                DiceGame = diceGame;
                Action = action;
            }
        }
    }
}
