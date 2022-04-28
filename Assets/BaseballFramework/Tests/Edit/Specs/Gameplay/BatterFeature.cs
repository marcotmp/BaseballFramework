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
            var player1InputController = new BFInputController();
            var batterHumanController = new BatterHumanController(player1InputController);
            batterHumanController.SetBatter(batter);
            batter.startSwingAnimation = () => isSwinging = true;

            // batter should be in human idle state
            // batter.SetState(batter.idleState);

            // when
            player1InputController.buttonB = true;
            batter.Update(0);

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
            var batterHumanController = new BatterHumanController(new BFInputController());
            batterHumanController.SetBatter(batter);
            batter.onMove = (Vector3 movement) => { m = movement; };

            // when
            batterHumanController.inputController.dPadUp = false;
            batter.Update(0);
            Assert.AreEqual(m.y, 0, "Batter should not move");

            batterHumanController.inputController.dPadUp = true;
            batter.Update(0);
            // then StartSwing event was called
            Assert.AreEqual(m.y, 1, "Batter should swing the bat");
        }

        [Test]
        // when game is in batting state
        public void AllowBattingInBattingState()
        {
            bool isSwinging = false;
            var game = new BFGame();
            var batter = new BFBatter();
            var inputController = new BFInputController();
            var batterHumanController = new BatterHumanController(inputController);
            batterHumanController.SetBatter(batter);
            game.SetState(GameState.BattingAndPitching);

            // when buttonA is pressed
            inputController.buttonA = true;
            // and game updates
            game.Update(0);

            // then StartSwing event was called
            Assert.IsTrue(isSwinging, "Batter should swing the bat");
        }

        [Test]
        // when game is in batting state
        public void ButtonA_NotPressed_DontStartBatAnimation()
        {
            bool isSwinging = false;
            var game = new BFGame();
            var batter = new BFBatter();
            var inputController = new BFInputController();
            var batterHumanController = new BatterHumanController(inputController);
            batterHumanController.SetBatter(batter);
            game.SetState(GameState.BattingAndPitching);

            // when buttonA is pressed
            inputController.buttonA = false;
            // and game updates
            game.Update(0);

            // then StartSwing event was not called
            Assert.IsFalse(isSwinging, "Batter should not swing the bat");
        }

        // when game is not in batting state
        [Test]
        public void WhenGameIsNotInBattingAndPitchingState_DontProcessControllers()
        {
            bool isSwinging = false;
            var game = new BFGame();
            var batter = new BFBatter();
            var inputController = new BFInputController();
            var batterHumanController = new BatterHumanController(inputController);
            batterHumanController.SetBatter(batter);
            batter.startSwingAnimation = () => isSwinging = true;
            game.SetState(GameState.Strike);

            // when buttonA is pressed
            inputController.buttonA = true;
            // and game updates
            game.Update(0);

            // then StartSwing event was not called
            Assert.IsFalse(isSwinging, "Batter should not swing the bat");
        }

        // when batter is CPU don't effect any action
    }
}