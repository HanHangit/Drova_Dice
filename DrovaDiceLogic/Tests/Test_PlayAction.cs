using System;
using DrovaDiceLogic;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.DiceGameSettings;
using DrovaDiceLogic.Moves;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test_PlayAction
    {
        [TestMethod]
        public void PlayAction_Valid()
        {
            var diceGame = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());

            var playAction = new PlayAction();
            var selectAction = new SelectAction(new Dice(1));

            Assert.IsFalse(diceGame.CanBePlayed(playAction));

            diceGame.Play(selectAction);

            Assert.IsTrue(diceGame.CanBePlayed(playAction));
        }

        [TestMethod]
        public void PlayAction_ChangeHealth()
        {
            var diceGame = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());
            var player = diceGame.CurrentBoard.Players.Find(p => p.PlayerStats.ID != diceGame.CurrentBoard.CurrentPlayer.PlayerStats.ID);

            var playAction = new PlayAction();
            var selectAction = new SelectAction(new Dice(1));

            Assert.IsTrue(player.PlayerStats.Health == player.PlayerStats.MaxHealth);

            diceGame.Play(selectAction);
            diceGame.Play(playAction);

            Assert.IsTrue(player.PlayerStats.Health < player.PlayerStats.MaxHealth);
        }
    }
}
