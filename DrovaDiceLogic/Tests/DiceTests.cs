using System;
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

            var selectAction = new SelectAction(new Dice(1));

            Assert.IsTrue(diceGame.CanBePlayed(selectAction));

            diceGame.Play(selectAction);

            Assert.IsFalse(diceGame.CanBePlayed(selectAction));
        }
    }
}
