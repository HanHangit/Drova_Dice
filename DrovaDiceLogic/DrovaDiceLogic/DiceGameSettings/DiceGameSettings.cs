using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.Rules;

namespace DrovaDiceLogic.DiceGameSettings
{
    public class DiceGameSettings
    {
        private RoundStartSettings _startSettings = null;
        public RoundStartSettings StartSettings => _startSettings;
        private DiceSettings _diceSettings = null;
        public DiceSettings DiceSettings => _diceSettings;
        private PlayerSettings _playerPlayerSettings = null;
        public PlayerSettings PlayerPlayerSettings => _playerPlayerSettings;
        private RuleSettings _ruleSettings = null;
        public RuleSettings RuleSettings => _ruleSettings;

        public DiceGameSettings(RoundStartSettings roundStartSettings, DiceSettings diceSettings, PlayerSettings playerSettings, RuleSettings ruleSettings)
        {
            _startSettings = roundStartSettings;
            _diceSettings = diceSettings;
            _playerPlayerSettings = playerSettings;
            _ruleSettings = ruleSettings;
        }

        public static DiceGameSettings CreateDefaultGameSettings()
        {
            return new DiceGameSettings(
                    new RoundStartSettings(6, 2, 3),
                    new DiceSettings(1, 6),
                    new PlayerSettings(20, 5),
                    new RuleSettings(new List<Rule>
                    {
                        new Rule(
                                new List<ActionRule>
                                {
                                    new ChangeAmmoRule(ActionTarget.Self, 1)
                                },
                                new List<ARestriction>
                                {
                                    new DiceRestriction(new List<Dice>()
                                    {
                                        new Dice(0,1)
                                    })
                                }),
                        new Rule(
                                new List<ActionRule>
                                {
                                        new ChangeAmmoRule(ActionTarget.Self, 3)
                                },
                                new List<ARestriction>
                                {
                                        new DiceRestriction(new List<Dice>()
                                        {
                                                new Dice(0,2),
                                                new Dice(0, 2)
                                        })
                                }),
                        new Rule(
                                new List<ActionRule>
                                {
                                        new ShootRule(ActionTarget.Enemy, -1, 1, -1)
                                },
                                new List<ARestriction>
                                {
                                        new DiceRestriction(new List<Dice>()
                                        {
                                                new Dice(0,3)
                                        }),
                                        new AmmoRestriction(1)
                                }),
                        new Rule(
                                new List<ActionRule>
                                {
                                        new ShootRule(ActionTarget.Enemy, -1, 2, -1),
                                        new ChangeAmmoRule(ActionTarget.Self, 1)
                                },
                                new List<ARestriction>
                                {
                                        new DiceRestriction(new List<Dice>()
                                        {
                                                new Dice(0,3),
                                                new Dice(0,3)
                                        }),
                                        new AmmoRestriction(1)
                                }),
                        new Rule(
                                new List<ActionRule>
                                {
                                        new ShootRule(ActionTarget.Enemy, -1, 3, -1),
                                        new ChangeAmmoRule(ActionTarget.Self, 2)
                                },
                                new List<ARestriction>
                                {
                                        new DiceRestriction(new List<Dice>()
                                        {
                                                new Dice(0,3),
                                                new Dice(0,3),
                                                new Dice(0,3)
                                        }),
                                        new AmmoRestriction(1)
                                }),
                        new Rule(
                                new List<ActionRule>
                                {
                                        new ChangeAmmoRule(ActionTarget.Self, 1)
                                },
                                new List<ARestriction>
                                {
                                        new DiceRestriction(new List<Dice>()
                                        {
                                                new Dice(0,4),
                                                new Dice(0,4)
                                        })
                                }),
                        new Rule(
                                new List<ActionRule>
                                {
                                        new ChangeAmmoRule(ActionTarget.Self, 2)
                                },
                                new List<ARestriction>
                                {
                                        new DiceRestriction(new List<Dice>()
                                        {
                                                new Dice(0,4),
                                                new Dice(0,4),
                                                new Dice(0,4)
                                        })
                                }),
                        new Rule(
                                new List<ActionRule>
                                {
                                        new ChangeHealthRule(ActionTarget.Self, 1)
                                },
                                new List<ARestriction>
                                {
                                        new DiceRestriction(new List<Dice>()
                                        {
                                                new Dice(0,5),
                                                new Dice(0,5)
                                        })
                                }),
                        new Rule(
                                new List<ActionRule>
                                {
                                        new ChangeHealthRule(ActionTarget.Self, 2)
                                },
                                new List<ARestriction>
                                {
                                        new DiceRestriction(new List<Dice>()
                                        {
                                                new Dice(0,5),
                                                new Dice(0,5),
                                                new Dice(0,5)
                                        })
                                }),
                        new Rule(
                                new List<ActionRule>
                                {
                                        new PatzerRule(ActionTarget.Self, -1, -1)
                                },
                                new List<ARestriction>
                                {
                                        new DiceRestriction(new List<Dice>()
                                        {
                                                new Dice(0,6),
                                        })
                                })
                    }));
        }
    }
}
