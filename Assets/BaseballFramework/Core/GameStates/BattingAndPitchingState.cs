using MarcoTMP.BaseballFramework.Core.States;
using System;

namespace MarcoTMP.BaseballFramework.Core.GameStates
{
    public class BattingAndPitchingState : GameState
    {        
        public IPitchingRules pitchingRules;
        public ProcessPitch pitchResult;
        public BFCatcher catcher;
        public BFGame game;
        override public void Enter()
        {
            pitchResult.Reset();
            pitchResult.Init();

            //pitchingRules.InitPitching();
            game.InitPitching();

        }

        override public void Exit()
        {
            //pitchingRules.FinishPitching();
            game.FinishPitching();
            pitchResult.Finish();

        }

        override public void Update(float dt)
        {
            //pitchingRules.HandleBattingAndPitching(dt);
            game.HandleBattingAndPitching(dt);

            if (pitchResult.IsStrikeOut())
                fsm.ChangeStateByType<StrikeOutState>();
            else if (pitchResult.IsStrike())
                fsm.ChangeStateByType<StrikeState>();
            else if (pitchResult.IsBall())
                fsm.ChangeStateByType<BallGameState>();

            // Hit
            else if (pitchResult.IsHit())
                fsm.ChangeStateByType<RunningAndCatchingState>();
            // Steal
            else if (game.CheckStealBase())
                fsm.ChangeStateByType<RunningAndCatchingState>();
        }
    }
}