using MarcoTMP.BaseballFramework.Core.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcoTMP.BaseballFramework.Core.GameStates
{
    public class StrikeState : GameState
    {
        public float delay = 1;
        private Timer timer = new Timer();

        public override void Enter()
        {
            base.Enter();
            timer.Reset(delay);
            game.ShowStrikeMessage();
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            // wait for a few seconds
            // and go back to PitchingState

            if (timer.Tick(dt))
                fsm.ChangeStateByType<BattingAndPitchingState>();
        }

        public override void Exit()
        {
            base.Exit();

            game.HideStrikeMessage();
        }
    }
}
