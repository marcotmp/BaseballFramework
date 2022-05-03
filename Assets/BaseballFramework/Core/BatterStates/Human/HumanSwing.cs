using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcoTMP.BaseballFramework.Core.BatterStates.Human
{
    public class HumanSwing : BatterSwing
    {
        public Timer timer = new Timer();

        override public void Enter() 
        {
            timer.Reset(2);
            batter.DoSwing();
        }
        override public void Update(float dt)
        {
            // if animation completed, back to idle
            //if (batter.IsAnimationCompleted())
            if (timer.Tick(dt))
            {
                fsm.ChangeStateByType<HumanIdle>();
            }

        }
        override public void Exit() { }
    }
}
