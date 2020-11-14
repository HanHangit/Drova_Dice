using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.DiceGameSettings;

namespace DrovaDiceLogic.BoardLogic
{
    public class Board : DiceSettingsObject
    {
        private List<Dice> _dices = new List<Dice>();
        public List<Dice> Dices => _dices;
        private List<Player> _players = new List<Player>();
        public List<Player> Players => _players;
        private Player _currentPlayer = null;
        public Player CurrentPlayer => _currentPlayer;

        public delegate void PlayerRoundEndedDelegate(RoundEndedEventArgs args);

        public event PlayerRoundEndedDelegate BoardRoundEndedEvent;

        internal Board(DiceGameSettings.DiceGameSettings gameSettings) : base(gameSettings)
        {
            for (int i = 0; i < gameSettings.StartSettings.NumDices; ++i)
            {
                AddDice(new Dice(i, i, gameSettings.DiceSettings));
            }

            Reroll();
        }

        private void InitPlayer()
        {
            for (int i = 0; i < GameSettings.StartSettings.NumPlayers; i++)
            {
                _players.Add(new Player(GameSettings.PlayerSettings, new PlayerStats(i, GameSettings.PlayerSettings.MaxHealth, GameSettings.PlayerSettings.MaxAmmo, GameSettings)));
            }
        }

        internal void Reroll()
        {
            foreach (var dice in _dices)
            {
                dice.Reroll();
            }
        }

        internal void RerollDices()
        {
            foreach (var dice in _dices)
            {
                if (dice.HasModifier(DiceModifier.CanBeRerolled))
                {
                    dice.Reroll();
                }
            }
        }

        internal void EndRound()
        {
            int oldID = _currentPlayer.PlayerStats.ID;
            _currentPlayer = _players.Find(p => p.PlayerStats.ID != _currentPlayer.PlayerStats.ID);
            var oldPlayer = _players.Find(p => p.PlayerStats.ID == oldID);
            BoardRoundEndedEvent?.Invoke(new RoundEndedEventArgs(oldPlayer, _currentPlayer));
        }

        internal void AddDice(Dice dice)
        {
            _dices.Add(dice);
        }

        internal void ClearBoard()
        {
            _dices.Clear();
        }

        public Dice GetDice(int id)
        {
            return _dices.Find(d => d.Id == id);
        }

        public Player GetPlayer(int id)
        {
            return _players.Find(d => d.PlayerStats.ID == id);
        }

        public class RoundEndedEventArgs
        {
            private Player _oldPlayer = null;
            private Player _newPlayer = null;

            public Player OldPlayer => _oldPlayer;
            public Player NewPlayer => _newPlayer;

            public RoundEndedEventArgs(Player oldPlayer, Player newPlayer)
            {
                _oldPlayer = oldPlayer;
                _newPlayer = newPlayer;
            }
        }
    }
}
