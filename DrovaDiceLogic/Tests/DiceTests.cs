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
    public class DiceTests
    {
        [TestMethod]
        public void Dice_Board()
        {
            var diceGame = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());
            diceGame.CurrentBoard.SetDices(new List<Dice>
            {
                new Dice(0,4),
                new Dice(1,4),
                new Dice(2,4),
                new Dice(3,4),
                new Dice(4,4),
                new Dice(5,4),
            });

            var selectAction = new SelectAction(new Dice(1));

            Assert.IsTrue(diceGame.CanBePlayed(selectAction));

            diceGame.Play(selectAction);

            Assert.IsFalse(diceGame.CanBePlayed(selectAction));
        }
    }
}
