using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.Rules;

namespace DrovaDiceLogic.Moves
{
    public class PlayAction : AAction
    {
        public PlayAction() : base(null)
        {

        }

        internal override bool ValidateGameAction(DiceGame game)
        {
            var rules = game.DiceGameSettings.RuleSettings.Rules;

            return rules.Any(r => r.CanPlayRule(game));
        }

        internal override void PlayGameAction(DiceGame game)
        {
            if (ValidateGameAction(game))
            {
                var rule = game.DiceGameSettings.RuleSettings.Rules.Find(f => f.CanPlayRule(game));
                rule.PlayRule(game);
            }
        }
    }
}
