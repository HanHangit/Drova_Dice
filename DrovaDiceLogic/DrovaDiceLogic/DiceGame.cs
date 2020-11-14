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

        public delegate void ActionEndedDelegate(GameTurnEndedEventArgs args);
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

        public bool CanBePlayed(AGameTurn action)
        {
            return action.ValidateGameAction(this);
        }

        public bool Play(AGameTurn action)
        {
            if (action.ValidateGameAction(this))
            {
                action.PlayGameAction(this);
                ActionEndedEvent?.Invoke(new GameTurnEndedEventArgs(this, action));
                return true;
            }

            return false;
        }

        public struct GameTurnEndedEventArgs
        {
            public DiceGame DiceGame;
            public AGameTurn GameTurn;

            public GameTurnEndedEventArgs(DiceGame diceGame, AGameTurn gameTurn)
            {
                DiceGame = diceGame;
                GameTurn = gameTurn;
            }
        }
    }
}
