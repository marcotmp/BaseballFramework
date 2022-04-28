using MarcoTMP.BaseballFramework.Core;
using MarcoTMP.BaseballFramework.Core.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcoTMP.BaseballFramework.Core.BatterStates
{
    public class BatterState : IState<BFBatter>
    {
        public FiniteStateMachine<BFBatter> fsm { get; set; }
        
        protected BFBatter batter => fsm.owner;

        virtual public void Enter()
        {
            throw new NotImplementedException();
        }

        virtual public void Exit()
        {
            throw new NotImplementedException();
        }

        virtual public void Update(float dt)
        {
            throw new NotImplementedException();
        }
    }

    //public class BatterIdle : BatterState {}
    public class BatterMove : BatterState { }
    public class BatterSwing : BatterState { }

}
