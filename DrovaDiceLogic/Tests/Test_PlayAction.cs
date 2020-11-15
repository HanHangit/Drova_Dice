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
    public class Test_PlayAction
    {
        [TestMethod]
        public void PlayAction_Valid()
        {
            var diceGame = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());
            diceGame.CurrentBoard.SetDices(new List<Dice>
            {
                    new Dice(0,1),
                    new Dice(1,1),
                    new Dice(2,2),
                    new Dice(3,3),
                    new Dice(4,4),
                    new Dice(5,5),
            });

            var playAction = new PlayAction(0);
            var selectAction = new SelectAction(new Dice(1));

            Assert.IsFalse(diceGame.CanBePlayed(playAction));

            diceGame.Play(selectAction);

            Assert.IsTrue(diceGame.CanBePlayed(playAction));
        }

        [TestMethod]
        public void PlayAction_SelfTarget()
        {
            var diceGame = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());
            var player = diceGame.CurrentBoard.CurrentPlayer;
            var enemy = diceGame.CurrentBoard.EnemyPlayers[0];
            enemy.PlayerStats.ChangeAmmo(1, this);
            diceGame.CurrentBoard.SetDices(new List<Dice>
            {
                    new Dice(0,1),
                    new Dice(1,1),
                    new Dice(2,2),
                    new Dice(3,3),
                    new Dice(4,4),
                    new Dice(5,5),
            });

            var playAction = new PlayAction(player.PlayerStats.ID);
            var selectAction = new SelectAction(new Dice(3));

            Assert.IsFalse(diceGame.CanBePlayed(playAction));

            diceGame.Play(selectAction);
            diceGame.Play(playAction);

            Assert.IsTrue(player.PlayerStats.Health == player.PlayerStats.MaxHealth - 1);
        }

        [TestMethod]
        public void PlayAction_Rule()
        {
            var diceGame = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());
            var enemy = diceGame.CurrentBoard.Players.Find(p => p.PlayerStats.ID != diceGame.CurrentBoard.CurrentPlayer.PlayerStats.ID);
            var player = diceGame.CurrentBoard.CurrentPlayer;
            player.PlayerStats.ChangeAmmo(1, this);
            var board = diceGame.CurrentBoard;

            board.SetDices(new List<Dice>
            {
                    new Dice(0, 3, diceGame.DiceGameSettings.DiceSettings),
                    new Dice(1, 3, diceGame.DiceGameSettings.DiceSettings),
                    new Dice(2, 3, diceGame.DiceGameSettings.DiceSettings),
                    new Dice(3, 5, diceGame.DiceGameSettings.DiceSettings),
            });

            board.GetDice(0).AddModifier(DiceModifier.Selected);
            board.GetDice(1).AddModifier(DiceModifier.Selected);
            board.GetDice(2).AddModifier(DiceModifier.Selected);

            diceGame.Play(new PlayAction(enemy.PlayerStats.ID));

            var usedDices = board.GetUsedDices();

            Assert.IsTrue(usedDices.Count == 3);
            Assert.IsTrue(usedDices[0].HasModifier(DiceModifier.Used));
            Assert.IsTrue(usedDices[1].HasModifier(DiceModifier.Used));
            Assert.IsTrue(usedDices[2].HasModifier(DiceModifier.Used));

            Assert.IsTrue(player.PlayerStats.Ammo == 0);
            Assert.IsTrue(enemy.PlayerStats.Health == player.PlayerStats.MaxHealth - 3);
        }
    }
}
