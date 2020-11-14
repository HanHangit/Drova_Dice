using System;
using System.Linq;
using DrovaDiceLogic;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.DiceGameSettings;
using DrovaDiceLogic.Moves;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test_SaveAction
    {
        [TestMethod]
        public void SaveAction_Valid()
        {
            var diceGame = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());

            var saveAction = new SaveAction();
            var selectAction = new SelectAction(new Dice(1));

            Assert.IsFalse(diceGame.CanBePlayed(saveAction));

            diceGame.Play(selectAction);

            Assert.IsTrue(diceGame.CanBePlayed(saveAction));
        }

        [TestMethod]
        public void PlayAction_ChangeHealth()
        {
            var diceGame = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());
            var player = diceGame.CurrentBoard.Players.Find(p => p.PlayerStats.ID != diceGame.CurrentBoard.CurrentPlayer.PlayerStats.ID);

            var playAction = new SaveAction();
            var selectAction = new SelectAction(new Dice(1));

            diceGame.Play(selectAction);
            diceGame.Play(playAction);

            Assert.IsTrue(diceGame.CurrentBoard.Dices.Any(d => d.HasModifier(DiceModifier.Saved)));
        }
    }
}
