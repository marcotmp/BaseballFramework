using MarcoTMP.BaseballFramework.Core;
using NUnit.Framework;
using System;

namespace Assets.BaseballFramework.Tests.Edit.Unit
{
    public class BFPitcherTest
    {
        private BFPitcher pitcher;

        [SetUp]
        public void Init()
        {
            pitcher = new BFPitcher();
        }

        [Test]
        public void OnStartPitching_EnablePitching()
        {
            // on start pitching
            // go to pitching state
            pitcher.StartPitching();

            pitcher.Update(1);

            // call pick
            //Assert.Equals(pitcher.state, "Pitching");
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
            pitcher.OnStartPitchingAnim = () => { animStarted = true; };

            pitcher.state = "THINK";
            pitcher.Update(0.5f);
            Assert.AreEqual("THINK", pitcher.state);

            pitcher.Update(0.5f);
            Assert.AreEqual("PITCHING", pitcher.state);
            Assert.IsTrue(animStarted, "Should start animation");
        }

        [Test]
        public void Pitching_To_Throw()
        {
            bool isThrowingBall = false;
            pitcher.onReleaseBall = () => { isThrowingBall = true; };

            // Given pitcher is on pitching state
            pitcher.state = "PITCHING";

            // When anim is in frame to release the ball
            pitcher.ReleaseBall();

            // Then ball start moving
            Assert.IsTrue(isThrowingBall, "releasBall should be dispatched");
        }

        [Test]
        public void PITCHING_To_IDLE()
        {
            // when animation stop
            // change to idle
            pitcher.AnimationCompleted();
            Assert.AreEqual("PITCHING", pitcher.state);
        }

        //[TestCase(0, "Rect")]
        //[TestCase(1, "CurveRight")]
        //[TestCase(2, "CurveLeft")]
        //[TestCase(3, "SlowBall")]
        //[TestCase(4, "TrickBall")]
        //public void AIPickLanzamiento(int random, string strategy)
        //{
        //    // Given
        //    var controller = new PitcherAIController();
        //    controller.randomSelector = () => random;
        //    pitcher.SetController(controller);

        //    // When
        //    pitcher.Update();

        //    // Then
        //    Assert.AreEqual(pitcher.estrategy, strategy);
        //}

        //public void HumanPickLanzamiento()
        //{
        //    // when press Up
        //    // lanza recta

        //    // Given
        //    var controller = new PitcherHumanController();
        //    controller.pressUp = true;
        //    pitcher.SetController(controller);

        //    // When
        //    pitcher.Update(1);

        //    // Then
        //    Assert.AreEqual(pitcher.estrategy, "recta");

        //}


        //[TestCase(0, "Rect")]
        //[TestCase(1, "CurveRight")]
        //[TestCase(2, "CurveLeft")]
        //[TestCase(3, "SlowBall")]
        //[TestCase(4, "TrickBall")]
        //public void BallHasLanzamiento(int random, string ballStrategy)
        //{
        //    // when pitcher select rect
        //    // the ball moves in a rect

        //    pitcher.state = "pitching";
        //    pitcher.randomeSelector = () => random;
        //    pitcher.Update();
        //    Assert.AreEqual(pitcher.estrategy, ballStrategy);
        //}

        //[Test]
        //public void AIPitcherWaitAFewSeconds()
        //{

        //    var animationCalled = false;
        //    pitcher.state = "pitching";
        //    pitcher.thinkingTime = 3;
        //    pitcher.Update();
        //    pitcher.InitAnimation = () => animationCalled = true;

        //    Assert.AreEqual(true, animationCalled, "was not called");
        //}
    }

    public class Pitcher
    {
        public string state;
        public GameEvent listenEvent;
        public string estrategy;
        public int thinkingTime;
        public Ball ballReference;
        private PitcherController controller;

        public Func<object> InitAnimation { get; internal set; }

        internal void FrameDeLanzamiento()
        {
            throw new NotImplementedException();
        }

        internal void SetController(PitcherController controller)
        {
            this.controller = controller;
        }

        internal void Update()
        {
            controller.Update();
        }
    }

    public class PitcherController
    {
        internal void Update()
        {
            throw new NotImplementedException();
        }
    }

    public class PitcherAIController : PitcherController
    {
        internal Func<int> randomSelector;// = () => UnityEngine.Random.Range(0, 5);
    }

    public class PitcherHumanController : PitcherController
    {
        internal bool pressUp;
    }

    public class GameEvent
    {
        internal void RaiseEvent(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class Ball
    {
        internal bool isMoving;
    }
}