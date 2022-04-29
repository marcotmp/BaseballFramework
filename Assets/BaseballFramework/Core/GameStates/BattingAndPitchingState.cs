using MarcoTMP.BaseballFramework.Core.States;
using System;

namespace MarcoTMP.BaseballFramework.Core.GameStates
{
    public class BattingAndPitchingState : GameState
    {        
        public IPitchingRules pitchingRules;

        override public void Enter()
        {
            //game.catcher.OnCatch => game.BallTouchHome();
            pitchingRules.InitPitching();
        }

        override public void Exit()
        {
            pitchingRules.FinishPitching();
        }

        override public void Update(float dt)
        {
            pitchingRules.HandleBattingAndPitching(dt);

            // StrikeOut
            //if (gameRules.CheckIsStrikeOut())
            if (pitchingRules.CheckIsStrikeOut())
            //if (checkIsStrikeOut())
                fsm.ChangeStateByType<StrikeOutState>();
            // Strike
            else if (pitchingRules.IsStrike)
            //else if (checkIsStrike())
                fsm.ChangeStateByType<StrikeState>();
            else if (pitchingRules.CheckIsBall())
            //else if (checkIsBall())
                fsm.ChangeStateByType<BallGameState>();
            // Hit
            else if (pitchingRules.CheckIsHit())
            //else if (checkIsHit())
                fsm.ChangeStateByType<RunningAndCatchingState>();
            // Steal
            else if (pitchingRules.CheckStealBase())
            //else if (checkOffensiveTryToStealBase())
                fsm.ChangeStateByType<RunningAndCatchingState>();
        }
    }
}