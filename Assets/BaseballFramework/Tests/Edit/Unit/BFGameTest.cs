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
        public void GameHas9Innings()
        {

        }

        [Test]
        public void OnFirstHalfOffensiveIsHomeAndDeffensiveIsVisitor()
        {

        }

        [Test]
        public void DeffensiveAndOffensiveChangeWhenInningComplete()
        {
            //game.innings.ofensive = "Aguilas";
            //game.innings.defensive = "Licey";

            //game.innings.CompleteInning();

            //Assert.AreEquals("Licey", game.innings.ofensive);
            //Assert.AreEquals("Aguilas", game.innings.defensive);
        }
    }
}