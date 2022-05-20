using MarcoTMP.BaseballFramework.Core;
using MarcoTMP.BaseballFramework.HomerunDerby;
using NSubstitute;
using NUnit.Framework;
using System;
using UnityEngine;

namespace Assets.BaseballFramework.Tests.Edit.Unit.Derby
{
    // Description:
    // file:C:\Dev\Repositories\Baseball\Assets\BaseballFramework\Tests\Edit\Specs\Gameplay\DerbyFeature.cs

    class DerbyGameTest
    {
        private DerbyGame derby;

        [SetUp]
        public void SetUp()
        {
            derby = new DerbyGame();
            derby.batter = Substitute.For<BFBatter>();
            derby.pitcher = Substitute.For<BFPitcher>();
            derby.timer = Substitute.For<DerbyTimer>();
            derby.catcher = Substitute.For<BFCatcher>();
            derby.ball = Substitute.For<BFBall>();
            derby.message = Substitute.For<IMessage>();
            derby.scoreboard = Substitute.For<DerbyScoreboard>();
        }

        [Test]
        public void InitDerby() 
        {
            derby.Init();

            derby.batter.Received().Init();
            derby.pitcher.Received().Init();
            derby.timer.Received().Init();
        }

        [Test]
        public void TestStartPitchingAndBatting()
        {
            derby.Init();
            derby.pitcher.Received().Activate();
            derby.batter.Received().Activate();
        }

        [Test]
        public void Test_OnCatcherGetBall_ReactivatePitcherBatter()
        {
            derby.Init();

            derby.catcher.CatchBall();

            derby.pitcher.Received().Activate();
            derby.batter.Received().Activate();
        }

        [Test]
        public void Test_OnHitBall()
        {
            derby.ProcessHit();
            derby.ball.Received().MoveTo(Vector3.zero);
        }


        [Test]
        public void Test_Homerun()
        {
            derby.Init();

            // when ball land on homerun
            derby.ball.LandOnHomerun();
            
            // show message
            derby.message.Received().Show(3, Arg.Any<Action>());

            // and add homerun
            Assert.AreEqual(1, derby.scoreboard.homerun, "score");
        }

        public void TestFromHomerunBackToPitching()
        {
            // derby.mesage = message;
            // when message complete
            // message.Complete();
            // reset batter / pitcher / ball
        }
    }

    class Derby
    {
        public Batter batter;
        public Pitcher pitcher;
        public Catcher catcher;
        public Timer timer;
        public Ball ball;

        public void Init()
        {
            catcher.OnCatchBall = OnCatchBall;
            batter.OnBatInPosition = ProcessHit;
            ball.OnLandOnField = BallLandOnField;

            timer.Init();
        }

        public void ActivateBatterAndPitcher()
        {
            // Set Ready state
            batter.Activate();
            // Set Ready state
            pitcher.Activate();
        }

        public void ProcessHit()
        {
            // if ball and bat in range
            //  select random hit direction
            //  and hit ball: HitBall();
            // else let ball move
        }

        public void BallLandOnField()
        {
            // Show distance stats
            // wait 3 seconds
            // message.ShowDistanceAsync(onComplete {
            //      ActivateBatterPitcher
            // }, 3)
        }

        public void BallLandOutOfField()
        {
            OnHomerun();            
        }


        private void OnCatchBall()
        {
            ActivateBatterAndPitcher();
        }

        private void OnHomerun()
        {
            // show homerun message
            // increase counter
            // wait for 3 seconds
            // ActivateBatterAndPitcher;

            //: if timer = 0: end derby
        }
    }
    class Batter
    {
        public Action OnBatInPosition { get; internal set; }

        internal void Activate()
        {
            throw new NotImplementedException();
        }

        virtual internal void Init()
        {
            throw new NotImplementedException();
        }
    }
    class Pitcher
    {
        internal void Activate()
        {
            throw new NotImplementedException();
        }

        internal void Init()
        {
            throw new NotImplementedException();
        }
    }
    class Timer
    {
        internal void Init()
        {
            throw new NotImplementedException();
        }
    }
    class Catcher
    {
        public Action OnCatchBall { get; internal set; }
    }
    class Ball
    {
        public Action OnLandOnField { get; internal set; }

        internal void Hit(Vector3 v)
        {
            throw new NotImplementedException();
        }
    }

}



