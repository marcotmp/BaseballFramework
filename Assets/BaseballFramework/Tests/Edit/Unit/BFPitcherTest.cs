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

        //[Test]
        //public void PitcherInFrameLanzamiento_BallStartMoving()
        //{
        //    var fakeBall = new Ball();
        //    pitcher.ballReference = fakeBall;

        //    pitcher.FrameDeLanzamiento();
        //    // ball is released with the selected ball movement;

        //    Assert.IsTrue(fakeBall.isMoving);
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