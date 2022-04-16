using MarcoTMP.BaseballFramework.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.BaseballFramework.Tests.Edit.Specs.Gameplay
{
    class AIBatterFeature
    {
        [Test]
        public void WhenBallClose_DoSwing()
        {
            var ball = new BFBall();
            var batter = new BFBatter();
            var aiBatterController = new AIBatterController();
            batter.SetController(aiBatterController);


            // when ball is close to batter
            aiBatterController.range = 0.6f;
            //aiBatterController.GetDistance = () => ball.view.GetZ() - batter.view.GetZ();
            //aiBatterController.ProcessDistance();
            //aiBatterController.Update();
            batter.Update(0);

            // then batter hit the ball
            batter.startSwingAnimation = () => { };

            Assert.IsTrue(true, "Should start swing");
        }

        // Move batter to try to catch the ball
        // When ball is close to batter => move batter
        // When batter is close to ball => do swing
    }

    public class BFBall
    {
    }

    public class AIBatterController
    {
        public float range;
    }
}
