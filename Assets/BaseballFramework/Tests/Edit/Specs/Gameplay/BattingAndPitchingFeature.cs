using MarcoTMP.BaseballFramework.Core;
using NUnit.Framework;
using System;

namespace Assets.BaseballFramework.Tests.Edit.Specs.Gameplay
{
    class BattingAndPitchingFeature_Reactive
    {
        // Pitching result in a strike
        // Pitching result in a ball
        // Pitching result in a dead ball
        // Pitching result in a hit

        public void TestRectStrike()
        {
            bool onShowStrike = false;

            // Given game is in BattingAndPitching
            var game = new Game();
            game.OnShowStrike += () => onShowStrike = true;
            //game.SetState("BattingAndPitching");

            // And pitcher throws a rect ball
            //game.pitcher.ThrowRect();

            // When catcher catches the ball
            game.catcher.CatchBall();

            // Then show strike message
            Assert.True(onShowStrike);
        }

        public void TestCurveStrike()
        {
            // Given game is in BattingAndPitching
            // game.SetState(new BattingAndPitching());

            // And pitcher throws a curve ball
            // game.pitcher.Throw("rect");

            // And batter swing the bat
            // game.batter.Swing();

            // When catcher catches the ball
            // game.catcher.CatchBall();

            // Then show strike message
            // game.Received().ShowStrike();
        }

        public void TestStrikeOutChangeBatter()
        {
            // Given game is in BattingAndPitching
            // game.SetState("BattingAndPitching");

            // And pitcher throws a rect ball
            // game.pitcher.Throw("rect");

            // And board is strikes=2
            // game.board.strikes = 2;

            // When catcher catches the ball
            // game.catcher.CatchBall();

            // Then show strike message
            // game.Received().ShowStrike();

            // When 2 seconds has passed
            // game.Update(2);

            // Then show out message
            // game.Received().ShowOut();

            // When 2 seconds has passed
            // game.Update(2);

            // Then Change batter and back to BattingAndPitching
            // game.Received().ChangeBatter();
            // game.currentState.Type is BattingAndPitching;

        }

        public void TestStrikeOutChangeHalf()
        {
            // Given game is in BattingAndPitching
            // game.SetState("BattingAndPitching");

            // And pitcher throws a rect ball
            // And board is strikes=2
            // And board is out=2
            // When catcher catches the ball
            // Then show strike message
            // When 2 seconds has passed
            // Then show out message
            // When 2 seconds has passed
            // Then Show change half 
        }



        public void TestBall()
        {
            // Given game is in BattingAndPitching
            // And pitcher throws a curve ball
            // And batter didn't swing the bat
            // When catcher catches the ball
            // Then show ball message
        }

        public void TestDeadBall()
        {
            // Given game is in BattingAndPitching
            // And pitcher throws a curve ball
            // When ball touches batter
            // Then show DeadBall message
        }

        public void TestHit()
        {
            // Given game is in BattingAndPitching
            // And pitcher throws a rect ball
            // And batter swing the bat
            // When bat touches the ball
            // Then change to running and fielding
        }
    }

    public class Game // ProcessPitch
    {
        public Pitcher pitcher;
        public Catcher catcher;
        public Batter batter;

        public Action OnShowStrike;
        public Action OnShowBall;

        public HalfInningBoard board;
        

        public PitchBallResult result { get; private set; }


        public Action<PitchBallResult> onProcessResults;
        public Action OnHit;
        public Action OnDeadBall;

        public void Init()
        {
            catcher.onBallCatched = ProcessCatchBall;
            batter.OnDeadBall = ProcessDeadBall;
            batter.OnHit = ProcessHit;
        }

        private void ProcessDeadBall()
        {
            //result.Clear();
            //result.ballResult = BallResult.DeadBall;
            //onProcessResults?.Invoke(result);
            OnDeadBall?.Invoke();
        }

        private void ProcessHit()
        {
            //result.Clear();
            //result.ballResult = BallResult.Hit;
            OnHit();
        }

        [Obsolete]
        public void SetState(string v) 
        {
            //fps.ChangeState(v);
        }

        private void ProcessCatchBall() {
            bool ballTouchBatterZone = true;
            result.Clear();
            // debió ser ball, pero el player hizo swing, so, es strike!
            if (batter.didSwing)
                result.ballResult = BallResult.Strike;
            else
            {
                if (ballTouchBatterZone)
                    result.ballResult = BallResult.Ball;
                else
                    result.ballResult = BallResult.Strike;
            }

            if (result.ballResult == BallResult.Strike)
            {
                ProcessStrike();
                onProcessResults?.Invoke(result);
            }
        }

        private void ProcessStrike()
        {
            // if catch in center => strike
            // if catch in bat zone => ball
            board.strikes++;
            if (board.strikes > 3)
            {
                board.strikes = 0;

                // process outs
                board.outs++;

                result.@out = true;

                if (board.outs > 3)
                {

                    result.endOfHalf = true;

                    // result out and end of halg
                    //onEndOfHalf?.Invoke();
                    // Do strike => out => onChange
                }
                //else
                //{
                //    // result strike out
                //    //onOut?.Invoke();
                //    // Do strike => out
                //}
            }
            //else
            //{
            //    // result just strike
            //    //onStrike?.Invoke();
            //    // Do strike
            //}

            
        }
    }

    public class BattingAndPitching 
    {
    
    }
    public class Catcher
    {
        internal Action onBallCatched;

        public void CatchBall()
        {
        }
    }
    public class Pitcher
    {
        internal void ThrowRect()
        {
            throw new NotImplementedException();
        }
    }
    public class Batter
    {
        internal bool didSwing;

        public Action OnDeadBall { get; internal set; }
        public Action OnHit { get; internal set; }
    }

    public enum BallResult
    {
        None, Ball, DeadBall, Strike, Hit
    }
    public class PitchBallResult
    {
        public BallResult ballResult;
        internal bool @out;
        internal bool endOfHalf;

        internal void Clear()
        {
            ballResult = BallResult.None;
            @out = false;
            endOfHalf = false;
        }
    }
}
