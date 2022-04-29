using MarcoTMP.BaseballFramework.Core.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.BaseballFramework.Tests.Edit.Helpers
{
    class FakeFiniteStateMachine<T> : FiniteStateMachine<T>
    {
        public Type changeStateByTypeCalledWithParamU;
        public bool isUpdateCalled;
        public IState<T> changeStateCalledWithParamNewState;

        public FakeFiniteStateMachine()
        {
        }

        public override void ChangeToState(IState<T> newState)
        {
            changeStateCalledWithParamNewState = newState;
            currentState = newState;
        }

        public override void ChangeStateByType<U>()
        {
            changeStateByTypeCalledWithParamU = typeof(U);
        }

        public override void Update(float dt) { isUpdateCalled = true; }
    }
}
