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
    public class Test_Ammo
    {
        [TestMethod]
        public void PlayAction_AmmoChange_Both()
        {
            var diceGame = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());
            var player = diceGame.CurrentBoard.GetPlayer(0);
            var enemy = diceGame.CurrentBoard.GetPlayer(1);
            enemy.PlayerStats.ChangeAmmo(1, this);
            diceGame.CurrentBoard.SetDices(new List<Dice>
            {
                    new Dice(0,1, diceGame.DiceGameSettings.DiceSettings),
                    new Dice(1,1, diceGame.DiceGameSettings.DiceSettings),
                    new Dice(2,2, diceGame.DiceGameSettings.DiceSettings),
                    new Dice(3,4, diceGame.DiceGameSettings.DiceSettings),
                    new Dice(4,4, diceGame.DiceGameSettings.DiceSettings),
                    new Dice(5,6, diceGame.DiceGameSettings.DiceSettings)
            });

            var playAction = new PlayAction(0);
            var selectAction1 = new SelectAction(new Dice(3));
            var selectAction2 = new SelectAction(new Dice(4));

            diceGame.Play(selectAction1);
            diceGame.Play(selectAction2);

            diceGame.Play(playAction);

            Assert.IsTrue(player.PlayerStats.Ammo == 1);
            Assert.IsTrue(enemy.PlayerStats.Ammo == 0);
        }
    }
}
