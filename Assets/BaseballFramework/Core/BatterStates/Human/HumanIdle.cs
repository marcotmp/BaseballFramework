using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcoTMP.BaseballFramework.Core.BatterStates.Human
{
    public class HumanIdle : BatterState
    {
        BFInputController input;
        public HumanIdle(BFInputController input)
        {
            this.input = input;
        }

        override public void Enter() { }
        override public void Update(float dt)
        {
            if(input.buttonA)
                fsm.ChangeStateByType<HumanSwing>();
        }
        override public void Exit() { }
    }
}
