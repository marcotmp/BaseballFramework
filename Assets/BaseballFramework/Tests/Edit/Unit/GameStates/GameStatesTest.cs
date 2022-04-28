using MarcoTMP.BaseballFramework.Core;
using MarcoTMP.BaseballFramework.Core.GameStates;
using MarcoTMP.BaseballFramework.Core.States;
using NSubstitute;
using NUnit.Framework;
using System;

namespace Assets.BaseballFramework.Tests.Edit.Unit
{
    //public class GameStates
    //{
        //## Game States ##
        //BattingAndPitching
        //Strike
        //Out
        //Ball
        //StrikeOut
        //RunAndFielding
    //}



    public class BattingAndPitchingStateTest
    {
        BattingAndPitchingState battingState;
        FakeFiniteStateMachine fsm;
        IPitchingRules pitchingRules;

        [SetUp]
        public void Setup()
        {
            pitchingRules = Substitute.For<IPitchingRules>();
            fsm = new FakeFiniteStateMachine();
            battingState = new BattingAndPitchingState();
            battingState.pitchingRules = pitchingRules;
            battingState.fsm = fsm;
        }

        [Test]
        public void WhenEnterState_EnablePitcherAndBatter()
        {
            // Given state with pitcher
            var game = Substitute.For<IPitchingRules>();
            var state = new BattingAndPitchingState();
            state.pitchingRules = game;

            // when enter state
            state.Enter();

            // then batter and pitcher are active
            game.Received().InitPitching();

            // when exit state
            state.Exit();

            // then batter and pitcher are inactive
            game.Received().FinishPitching();
        }

        // When there is a strike, go to strike state
        [Test]
        public void WhenStrike_StrikeState()
        {
            pitchingRules.CheckIsStrike().Returns(true);

            battingState.Update(0);

            // change to strike
            Assert.AreEqual(typeof(StrikeState), fsm.changeStateByTypeCalledWithParamU);
        }

        // When there is a strike out, go to strikeOut state
        [Test]
        public void OnStrikeOut_ChangeToStrikeOut()
        {
            pitchingRules.CheckIsStrikeOut().Returns(true);

            battingState.Update(0);

            Assert.AreEqual(typeof(StrikeOutState), 
                fsm.changeStateByTypeCalledWithParamU);
        }



        // When there is a ball, go to ball state
        [Test]
        public void OnBall_ChangeToBall()
        {
            pitchingRules.CheckIsBall().Returns(true);

            battingState.Update(0);

            Assert.AreEqual(typeof(BallGameState),
                fsm.changeStateByTypeCalledWithParamU);
        }

        // When there is a foul, go to foul state
        // When there is a hit, go to RunningAndCatching
        [Test]
        public void OnHit_ChangeToRunningAndCatchingState()
        {
            pitchingRules.CheckIsHit().Returns(true);

            battingState.Update(0);

            Assert.AreEqual(typeof(RunningAndCatchingState),
                fsm.changeStateByTypeCalledWithParamU);
        }
    }

    public class StrikeStateTest
    {

        [Test]
        public void WhenEnterStrikeState_CallShowStrike()
        {
            var game = new BFGame();
            var listener = Substitute.For<IGameListener>();
            game.SetListener(listener);
            //game.SetState(GameState.Strike);

            listener.Received().ShowStrikeMessage();
        }
    }

    public class FakeFiniteStateMachine : FiniteStateMachine<BFGame>
    {
        public Type changeStateByTypeCalledWithParamU;

        public FakeFiniteStateMachine()
        {

        }

        public override void ChangeToState(IState<BFGame> newState)
        {
            //base.ChangeToState(newState);
            currentState = newState;
        }

        public override void ChangeStateByType<U>()
        {
            changeStateByTypeCalledWithParamU = typeof(U);
        }
    }

    public class FakeBatter : BFBatter
    {

    }

    public class FakePitcher : BFPitcher { }

}