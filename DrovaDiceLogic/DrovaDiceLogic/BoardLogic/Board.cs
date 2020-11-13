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

        public override void InitSettings(DiceGameSettings.DiceGameSettings gameSettings)
        {
            base.InitSettings(gameSettings);

            for (int i = 0; i < gameSettings.StartSettings.NumDices; ++i)
            {
                AddDice(new Dice(i, i, gameSettings.DiceSettings));
            }

            Roll();
        }

        internal void Roll()
        {
            foreach (var dice in _dices)
            {
                dice.Reroll();
            }
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
    }
}
