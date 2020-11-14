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

        [TestMethod]
        public void Dice_Reroll_CanReroll()
        {
            var diceGame = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());

            var selectAction1 = new SaveAction(new Dice(0));
            var selectAction2 = new SaveAction(new Dice(1));
            var selectAction3 = new SaveAction(new Dice(2));
            var selectAction4 = new SaveAction(new Dice(3));
            var selectAction5 = new SaveAction(new Dice(4));
            var selectAction6 = new SaveAction(new Dice(5));
            var unsaveAction = new UnsaveAction(new Dice(5));

            diceGame.Play(selectAction1);
            diceGame.Play(selectAction2);
            diceGame.Play(selectAction3);
            diceGame.Play(selectAction4);
            diceGame.Play(selectAction5);

            var rerollAction = new RerollTurn();
            Assert.IsTrue(diceGame.CanBePlayed(rerollAction));

            diceGame.Play(selectAction6);
            Assert.IsFalse(diceGame.CanBePlayed(rerollAction));

            diceGame.Play(unsaveAction);
            Assert.IsTrue(diceGame.CanBePlayed(rerollAction));
        }
    }
}
