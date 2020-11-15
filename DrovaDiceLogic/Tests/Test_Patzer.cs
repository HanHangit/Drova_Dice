using System;
using System.Collections.Generic;
using DrovaDiceLogic;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.DiceGameSettings;
using DrovaDiceLogic.Moves;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test_Patzer
    {
        [TestMethod]
        public void PlayAction_Valid()
        {
            var diceGame = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());
            diceGame.CurrentBoard.SetDices(new List<Dice>
            {
                    new Dice(0,1, diceGame.DiceGameSettings.DiceSettings),
                    new Dice(1,1, diceGame.DiceGameSettings.DiceSettings),
                    new Dice(2,2, diceGame.DiceGameSettings.DiceSettings),
                    new Dice(3,3, diceGame.DiceGameSettings.DiceSettings),
                    new Dice(4,4, diceGame.DiceGameSettings.DiceSettings),
                    new Dice(5,6, diceGame.DiceGameSettings.DiceSettings)
            });

            var playAction = new PlayAction(0);
            var selectAction = new SelectAction(new Dice(1));

            diceGame.Play(selectAction);

            Assert.IsTrue(diceGame.CurrentBoard.Players.TrueForAll(p => p.PlayerStats.Health < p.PlayerStats.MaxHealth));
        }
    }
}
