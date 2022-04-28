using MarcoTMP.BaseballFramework.Core.PitcherStates.AI;

namespace MarcoTMP.BaseballFramework.Core.States
{
    public interface IState<T>
    {
        FiniteStateMachine<T> fsm { get; set; }
        
        //FiniteStateMachine fsm { get; set; }
        void Enter();
        void Exit();
        void Update(float dt);
    }

    public interface IState : IState<object> { }

    public class StateBase<T> : IState<T>
    {
        public FiniteStateMachine<T> fsm { get; set; }
        
        virtual public void Enter()
        {
        }

        virtual public void Exit()
        {
        }

        virtual public void Update(float dt)
        {
        }
    }
}