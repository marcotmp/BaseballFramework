using Assets.BaseballFramework.Tests.Edit.Helpers;
using MarcoTMP.BaseballFramework.Core;
using MarcoTMP.BaseballFramework.Core.GameStates;
using MarcoTMP.BaseballFramework.Core.States;
using NSubstitute;
using NUnit.Framework;
using System;

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

        [Test] // this test could be moved to another testcase
        public void InitOnBattingAndPitchState()
        {
            // this code should be initialised in game;
            FakeFiniteStateMachine<BFGame> fsm = new FakeFiniteStateMachine<BFGame>();
            var state = new BattingAndPitchingState();
            fsm.AddState(state);
            var game = new BFGame();
            game.SetFSM(fsm);
            game.defaultState = state;

            game.Start();

            Assert.AreEqual(state, fsm.changeStateCalledWithParamNewState);
            //Assert.AreEqual(typeof(BattingAndPitchingState), fsm.changeStateByTypeCalledWithParamU);
        }

        [Test]
        public void UpdateFSM()
        {
            var fsm = new FakeFiniteStateMachine<BFGame>();
            var game = new BFGame();
            game.SetFSM(fsm);

            game.Update(0);

            Assert.IsTrue(fsm.isUpdateCalled);
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
    }
}