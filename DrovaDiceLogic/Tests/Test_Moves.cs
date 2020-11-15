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
    public class Test_Moves
    {
        [TestMethod]
        public void PlayAction_Rule()
        {
            var diceGame = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());
            var enemy = diceGame.CurrentBoard.Players.Find(p => p.PlayerStats.ID != diceGame.CurrentBoard.CurrentPlayer.PlayerStats.ID);
            var player = diceGame.CurrentBoard.CurrentPlayer;

            Assert.IsTrue(diceGame.CanBePlayed(new RerollTurn()));
            diceGame.Play(new RerollTurn());
            Assert.IsTrue(diceGame.CanBePlayed(new RerollTurn()));
            diceGame.Play(new RerollTurn());
            Assert.IsTrue(diceGame.CanBePlayed(new RerollTurn()));
            diceGame.Play(new RerollTurn());
            Assert.IsFalse(diceGame.CanBePlayed(new RerollTurn()));

            diceGame.Play(new EndRound());
            Assert.IsTrue(diceGame.CanBePlayed(new RerollTurn()));
        }

        [TestMethod]
        public void Move_SelectionPossible()
        {
            var diceGame = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());
            var enemy = diceGame.CurrentBoard.Players.Find(p => p.PlayerStats.ID != diceGame.CurrentBoard.CurrentPlayer.PlayerStats.ID);
            var player = diceGame.CurrentBoard.CurrentPlayer;

            Assert.IsTrue(diceGame.CanBePlayed(new RerollTurn()));
            diceGame.Play(new RerollTurn());
            Assert.IsTrue(diceGame.CanBePlayed(new RerollTurn()));
            diceGame.Play(new RerollTurn());
            Assert.IsTrue(diceGame.CanBePlayed(new RerollTurn()));
            diceGame.Play(new RerollTurn());
            Assert.IsTrue(diceGame.CanBePlayed(new SelectAction(new Dice(0))));
        }
    }
}
