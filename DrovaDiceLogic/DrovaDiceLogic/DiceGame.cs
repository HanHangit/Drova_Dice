using System;
using System.Collections.Generic;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.DiceGameSettings;
using DrovaDiceLogic.Moves;

namespace DrovaDiceLogic
{
    public class DiceGame
    {
        private DiceGameSettings.DiceGameSettings _diceGameSettings = null;
        public DiceGameSettings.DiceGameSettings DiceGameSettings => _diceGameSettings;
        private Board _currentBoard = null;
        public Board CurrentBoard => _currentBoard;

        public delegate void ActionEndedDelegate(GameMoveEndedEventArgs args);
        public event ActionEndedDelegate ActionEndedEvent;

        public DiceGame(DiceGameSettings.DiceGameSettings gameSettings)
        {
            _currentBoard = new Board(gameSettings);
            Init(gameSettings);
        }

        public void Init(DiceGameSettings.DiceGameSettings gameSettings)
        {
            _diceGameSettings = gameSettings;
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
            public AGameMove GameMove;

            public GameMoveEndedEventArgs(DiceGame diceGame, AGameMove gameMove)
            {
                DiceGame = diceGame;
                GameMove = gameMove;
            }
        }
    }
}
