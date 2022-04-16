using MarcoTMP.BaseballFramework.Core;
using NUnit.Framework;
using System;

namespace Assets.BaseballFramework.Tests.Edit.Unit
{
    /* 
 Pitcher States:
    IDLE:
        On Game.BattingAndPitching event: Think
    THINK:
        On Time elapsed: Pitching
    PITCHING:
        On finish animation: IDLE
*/

    public class AIPitcherControllerTest
    {
        //private AIPitcherController controller;
        private BFPitcher pitcher;

        [SetUp]
        public void Setup()
        {
            pitcher = new BFPitcher();
        }

        [Test]
        public void Test()
        {
            Assert.NotNull(pitcher);
        }

        [Test]
        public void PitcherStartInIDLEState()
        {
            Assert.AreEqual("IDLE", pitcher.state);
        }

        [Test]
        public void IDLE_To_THINK()
        {
            pitcher.StartPitching();

            Assert.AreEqual("THINK", pitcher.state);
        }

        [Test]
        public void THINK_To_PITCHING()
        {
            bool animStarted = false;
            pitcher.StartAnimation = () => { animStarted = true; };

            pitcher.state = "THINK";
            pitcher.Update(0.5f);
            Assert.AreEqual("THINK", pitcher.state);

            pitcher.Update(0.5f);
            Assert.AreEqual("PITCHING", pitcher.state);
            Assert.IsTrue(animStarted, "Should start animation"); 
        }

        [Test]
        public void PITCHING_To_IDLE()
        {
            // when animation stop
            // change to idle
            pitcher.AnimationCompleted();
            Assert.AreEqual("PITCHING", pitcher.state);
        }
    }
}
