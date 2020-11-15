using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.Rules;

namespace DrovaDiceLogic.Moves
{
    public class PlayAction : APlayerAction
    {
        public PlayAction(int playerID) : base(playerID)
        {

        }

        internal override bool ValidateGameAction(DiceGame game)
        {
            var rules = game.DiceGameSettings.RuleSettings.Rules;
            var player = game.CurrentBoard.GetPlayer(PlayerID);

            return player != null && rules.Any(r => r.CanPlayRule(game, player));
        }

        internal override void PlayGameAction(DiceGame game)
        {
            if (ValidateGameAction(game))
            {
                var player = game.CurrentBoard.GetPlayer(PlayerID);
                var rule = game.DiceGameSettings.RuleSettings.Rules.Find(f => f.CanPlayRule(game, player));
                rule.PlayRule(game, player);
            }
        }
    }
}
