using System;
using System.Collections.Generic;
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
        public void SaveAction_SelectionEmpty_Valid()
        {
            var diceGame = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());
            diceGame.CurrentBoard.SetDices(new List<Dice>
            {
                    new Dice(0,4),
                    new Dice(1,4),
                    new Dice(2,4),
                    new Dice(3,4),
                    new Dice(4,4),
            });

            var saveAction = new SaveAction();
            var selectAction = new SelectAction(new Dice(1));

            Assert.IsFalse(diceGame.CanBePlayed(saveAction));

            diceGame.Play(selectAction);

            Assert.IsTrue(diceGame.CanBePlayed(saveAction));
        }



        [TestMethod]
        public void SaveAction_InvalidSaveNumbers()
        {
            var diceGame = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());
            diceGame.CurrentBoard.SetDices(new List<Dice>
            {
                    new Dice(0,1),
                    new Dice(1,2),
                    new Dice(2,3),
                    new Dice(3,4),
                    new Dice(4,5),
            });
            var player = diceGame.CurrentBoard.Players.Find(p => p.PlayerStats.ID != diceGame.CurrentBoard.CurrentPlayer.PlayerStats.ID);

            var saveAction = new SaveAction();
            var selectAction1 = new SelectAction(new Dice(1));
            var unselectAction = new UnselectAction(new Dice(1));
            var selectAction5 = new SelectAction(new Dice(4));

            diceGame.Play(selectAction1);
            Assert.IsFalse(diceGame.CanBePlayed(saveAction));
            diceGame.Play(selectAction5);
            Assert.IsTrue(diceGame.CanBePlayed(saveAction));
            diceGame.Play(unselectAction);
            Assert.IsTrue(diceGame.CanBePlayed(saveAction));

        }

        [TestMethod]
        public void SaveAction_SavedDices()
        {
            var diceGame = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());
            diceGame.CurrentBoard.SetDices(new List<Dice>
            {
                    new Dice(0,4),
                    new Dice(1,4),
                    new Dice(2,4),
                    new Dice(3,4),
                    new Dice(4,4),
            });
            var player = diceGame.CurrentBoard.Players.Find(p => p.PlayerStats.ID != diceGame.CurrentBoard.CurrentPlayer.PlayerStats.ID);

            var playAction = new SaveAction();
            var selectAction = new SelectAction(new Dice(1));

            diceGame.Play(selectAction);
            diceGame.Play(playAction);

            Assert.IsTrue(diceGame.CurrentBoard.Dices.Any(d => d.HasModifier(DiceModifier.Saved)));
            Assert.IsTrue(diceGame.CurrentBoard.Dices.Any(d => !d.HasModifier(DiceModifier.CanBeRerolled)));

            diceGame.Play(new RerollTurn());
        }
    }
}
