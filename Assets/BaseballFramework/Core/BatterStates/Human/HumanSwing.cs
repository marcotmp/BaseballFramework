using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcoTMP.BaseballFramework.Core.BatterStates.Human
{
    public class HumanSwing : BatterSwing
    {
        override public void Enter() { }
        override public void Update(float dt)
        {
            // if animation completed, back to idle
            //if (batter.IsAnimationCompleted())
            fsm.ChangeStateByType<HumanIdle>();

        }
        override public void Exit() { }
    }
}
