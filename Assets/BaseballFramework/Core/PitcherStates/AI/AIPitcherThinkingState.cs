using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcoTMP.BaseballFramework.Core.PitcherStates.AI
{
    public class AIPitcherThinkingState : PitcherState
    {
        public int delayTime;
        private Timer timer;

        public AIPitcherThinkingState()
        {
            timer = new Timer();
        }

        public override void Enter()
        {
            base.Enter();
            timer.Reset(delayTime);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            
            if (timer.Tick(dt))
                fsm.ChangeStateByType<AIPitcherPitchingState>();
        }
    }
}
