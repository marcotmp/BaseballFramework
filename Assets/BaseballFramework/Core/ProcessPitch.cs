using MarcoTMP.BaseballFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcoTMP.BaseballFramework.Core
{
    public class ProcessPitch
    {
        public BFPitcher pitcher;
        public BFCatcher catcher;
        public BFBatter batter;
        public HalfInningBoard board;
        public Action<PitchBallResult> onProcessResults;

        public Action OnHit;
        public Action OnDeadBall;
        public PitchBallResult result { get; set; }

        public void Reset()
        {
            result.Clear();
        }

        public void Init()
        {
            catcher.OnBallCatched = ProcessCatchBall;
            batter.OnDeadBall = ProcessDeadBall;
            batter.OnHit = ProcessHit;
        }

        private void ProcessDeadBall()
        {
            result.Clear();
            OnDeadBall?.Invoke();
        }

        private void ProcessHit()
        {
            result.Clear();
            OnHit();
        }

        private void ProcessCatchBall()
        {
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
            board.strikes++;
            if (board.strikes > 3)
            {
                board.strikes = 0;

                // process outs
                board.outs++;

                result.@out = true;

                if (board.outs > 3)
                    result.endOfHalf = true;
                
            }
        }
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
