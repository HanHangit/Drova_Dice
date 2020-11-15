using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using DrovaDiceLogic.DiceGameSettings;

[assembly: InternalsVisibleTo("Tests")]
namespace DrovaDiceLogic.BoardLogic
{
    public class Board : DiceSettingsObject
    {
        private List<Dice> _dices = new List<Dice>();

        public List<Dice> Dices
        {
            get
            {
                var resultList = new List<Dice>();

                foreach (var dice in _dices)
                {
                    resultList.Add(dice.Clone() as Dice);
                }

                return resultList;
            }
        }
        private int _currentMove = 0;
        public int CurrentMove => _currentMove;

        private List<Player> _players = new List<Player>();
        public List<Player> Players => _players;
        private Player _currentPlayer = null;
        public Player CurrentPlayer => _currentPlayer;
        public List<Player> EnemyPlayers => _players.FindAll(p => p.PlayerStats.ID != _currentPlayer.PlayerStats.ID);

        public delegate void PlayerRoundEndedDelegate(RoundEndedEventArgs args);

        public event PlayerRoundEndedDelegate BoardRoundEndedEvent;

        internal Board(DiceGameSettings.DiceGameSettings gameSettings) : base(gameSettings)
        {
            InitPlayer();
            InitNewDices();
        }

        private void InitNewDices()
        {
            _dices.Clear();
            for (int i = 0; i < GameSettings.StartSettings.NumDices; ++i)
            {
                AddDice(new Dice(i, i, GameSettings.DiceSettings));
            }

            Reroll();
        }

        private void InitPlayer()
        {
            for (int i = 0; i < GameSettings.StartSettings.NumPlayers; i++)
            {
                _players.Add(new Player(GameSettings.PlayerPlayerSettings, new PlayerStats(i, GameSettings.PlayerPlayerSettings.MaxHealth, GameSettings.PlayerPlayerSettings.MaxAmmo, GameSettings)));
            }

            _currentPlayer = _players[0];
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

        internal void SetDices(List<Dice> dices)
        {
            _dices = dices;
        }

        internal void AddMove()
        {
            _currentMove++;
        }

        internal void ResetMoves()
        {
            _currentMove = 0;
        }

        public bool IsRerollPossible()
        {
            return _currentMove < GameSettings.StartSettings.NumRerolls;
        }

        internal void EndRound()
        {
            int oldID = _currentPlayer.PlayerStats.ID;
            _currentPlayer = _players.Find(p => p.PlayerStats.ID != _currentPlayer.PlayerStats.ID);
            var oldPlayer = _players.Find(p => p.PlayerStats.ID == oldID);
            _currentMove = 0;
            InitNewDices();
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

        internal Dice GetDice(int id)
        {
            return _dices.Find(d => d.Id == id);
        }

        public List<Dice> GetUsedDices()
        {
            return Dices.FindAll(d => d.HasModifier(DiceModifier.Used));
        }

        public List<Dice> GetActiveDices()
        {
            return Dices.FindAll(d => !d.HasModifier(DiceModifier.Used));
        }

        public List<Dice> GetSelectedDices()
        {
            return Dices.FindAll(d => d.HasModifier(DiceModifier.Selected) && !d.HasModifier(DiceModifier.Used));
        }

        public List<Dice> GetSavedDices()
        {
            return Dices.FindAll(d => d.HasModifier(DiceModifier.Saved));
        }

        public Player GetPlayer(int id)
        {
            return _players.Find(d => d.PlayerStats.ID == id);
        }

        public void CheckInstantRules(DiceGame game)
        {
            foreach (var rule in game.DiceGameSettings.RuleSettings.GetInstantRules())
            {
                if (rule.CanPlayRule(game))
                {
                    rule.PlayRule(game);
                }
            }
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
