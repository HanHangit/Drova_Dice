using System;
using System.Collections.Generic;
using System.Linq;
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
        private DiceGameStates _diceGameState = DiceGameStates.Running;
        public DiceGameStates DiceGameState => _diceGameState;

        public delegate void ActionEndedDelegate(GameTurnEndedEventArgs args);
        public event ActionEndedDelegate ActionEndedEvent;
        public delegate void GameEndedDelegate(GameEndedEventArgs args);
        public event GameEndedDelegate GameEndedEvent;

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
            if (DiceGameState == DiceGameStates.Running && ((!(action is RerollTurn) || _currentBoard.IsRerollPossible()) && action.ValidateGameAction(this)))
            {
                action.PlayGameAction(this);
                CurrentBoard.CheckInstantRules(this);
                CheckRoundEnd();
                CheckGameEnd();
                if (_diceGameState == DiceGameStates.Running)
                {
                    ActionEndedEvent?.Invoke(new GameTurnEndedEventArgs(this, action));
                }

                return true;
            }

            return false;
        }

        private void CheckRoundEnd()
        {
            if (!CurrentBoard.GetActiveDices().Any())
            {
                Play(new EndRound());
            }
        }

        private void CheckGameEnd()
        {
            if (_currentBoard.Players.Any(p => p.PlayerStats.Health <= 0))
            {
                _diceGameState = DiceGameStates.Finished;
                GameEndedEvent?.Invoke(new GameEndedEventArgs(this, _currentBoard.Players.Find(p => p.PlayerStats.Health > 0)));
            }
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


        public struct GameEndedEventArgs
        {
            public DiceGame Game;
            public Player Winner;

            public GameEndedEventArgs(DiceGame game, Player winner)
            {
                Game = game;
                Winner = winner;
            }
        }

        public enum DiceGameStates
        {
            Running,
            Finished
        }
    }
}
