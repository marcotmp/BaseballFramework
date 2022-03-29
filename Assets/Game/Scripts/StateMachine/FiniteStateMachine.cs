using System;
using System.Collections.Generic;

namespace MarcoTmp.States
{
    public class FiniteStateMachine
    {
        private IState currentState;
        private Dictionary<Type, IState> typeDict;

        public FiniteStateMachine()
        {
            typeDict = new Dictionary<Type, IState>();
        }

        public void AddState(IState state)
        {
            typeDict.Add(state.GetType(), state);
        }

        public void AddStateWithName(string name, IState state)
        {
            //stringDict.Add(stateName, state);
        }

        public void ChangeStateByName(string name)
        {
            // if find a state with name "name", change to it.
        }

        public void ChangeStateByType<T>()
        {
            // find state by T
            //if (typeof(dict.key) is T) return dict.value;

            // ChangeToState(state);
        }

        public void ChangeToState(IState newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
        }

        public void Update()
        {
            currentState?.Update();
        }

        public void FixedUpdate()
        {
            currentState?.FixedUpdate();
        }

    }
}