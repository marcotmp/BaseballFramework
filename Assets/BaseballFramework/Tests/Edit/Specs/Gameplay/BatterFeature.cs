using MarcoTMP.BaseballFramework.Core;
using NUnit.Framework;
using System;
using UnityEngine;

namespace Assets.Game.Tests.Edit.Specs.Gameplay.Batter
{
    public class BatterFeature : MonoBehaviour
    {
        // when user press bat button the batter makes a swing
        [Test]
        public void TestPressBatButton()
        {
            bool isSwinging = false;
            var batter = new BFBatter();
            var batterHumanController = new BatterHumanController();
            batterHumanController.SetBatter(batter);
            batter.startSwingAnimation = () => isSwinging = true;

            // when
            batterHumanController.PressBat();

            // then StartSwing event was called
            Assert.IsTrue(isSwinging, "Batter should swing the bat");
        }

        // when player press up, batter move up
        // when player press down, batter move down
        // when player press left, batter move left
        // when player press right, batter move right
        [Test]
        public void WhenPressMove()
        {
            Vector3 m = Vector3.zero;
            var batter = new BFBatter();
            var batterHumanController = new BatterHumanController();
            batterHumanController.SetBatter(batter);
            batter.onMove = (Vector3 movement) => { m = movement; };

            // when
            batterHumanController.MoveAxis(new Vector3(0, 1, 0));

            // then StartSwing event was called
            Assert.AreEqual(m.y, 1, "Batter should swing the bat");
        }


        // when game is in batting state
        public void AllowBattingInBattingMode()
        {
            bool isSwinging = false;
            var game = new BFGame();
            var batter = new BFBatter();
            var batterHumanController = new BatterHumanController();
            batterHumanController.SetBatter(batter);
            batter.startSwingAnimation = () => isSwinging = true;

            // when
            game.state = GameState.BattingAndPitching;
            // And
            batterHumanController.PressBat();

            // then StartSwing event was called
            Assert.IsFalse(isSwinging, "Batter should not swing the bat");
        }

        // when game is not in batting state

        // when batter is CPU don't effect any action
    }

}