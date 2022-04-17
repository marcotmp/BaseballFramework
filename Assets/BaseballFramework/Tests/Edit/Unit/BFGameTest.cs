using MarcoTMP.BaseballFramework.Core;
using NSubstitute;
using NUnit.Framework;

namespace Assets.BaseballFramework.Tests.Edit.Unit
{
    class BFGameTest
    {
        private BFGame game;

        [SetUp]
        public void SetUp()
        {
            game = new BFGame();
        }

        [Test]
        public void CreateBFGame()
        {
            Assert.NotNull(game);
        }

        [Test]
        public void InitOnBattingAndPitchState()
        {
            Assert.AreEqual(GameState.BattingAndPitching, game.state);
        }

        [Test]
        public void BattingAndPitchingUpdatePitcherAndBatter()
        {
            game.batterActor = Substitute.For<BFBatter>();
            game.pitcherActor = Substitute.For<BFPitcher>();

            game.Update(1);

            game.batterActor.Received().Update(1);
            game.pitcherActor.Received().Update(1);
        }

        [Test]
        public void GameHasTwoCompetitors()
        {
            Competitors teams = new Competitors();
            teams.home = new CompetingTeam();
            teams.visitor = new CompetingTeam();

            game.competitors = teams;

            Assert.NotNull(game.competitors);
            Assert.NotNull(game.competitors.home);
            Assert.NotNull(game.competitors.visitor);
        }

        [Test]
        public void PitcherThrowBall()
        {
            // when game enters pitching mode
            // then pitcher pitches the ball
        }

        [Test]
        public void WhenPitcherReleaseBall_BallMoveToHome()
        {
            // Given game is in batting and pitching state
            var game = new BFGame();
            var pitcher = new BFPitcher();
            var ball = new BFBall();
            game.pitcherActor = pitcher;
            game.ballActor = ball;
            game.SetState(GameState.BattingAndPitching);

            // When pitcher release the ball
            pitcher.ReleaseBall();
            Assert.AreEqual("Home", ball.moveTo);
        }

        [Test]
        public void WhenBallTouchBaseChangeToStrike()
        {
            var game = new BFGame();
            var pitcher = new BFPitcher();
            var ball = new BFBall();
            game.pitcherActor = pitcher;
            game.ballActor = ball;
            //game.SetState(GameState.BattingAndPitching);

            //When pelota toca al home
            game.BallTouchHome();

            Assert.AreEqual(GameState.Strike, game.state, "should be strike");
        }
    }
}