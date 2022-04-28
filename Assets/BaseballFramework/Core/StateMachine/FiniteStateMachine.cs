using MarcoTMP.BaseballFramework.Core.BatterStates.Human;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MarcoTMP.BaseballFramework.Core.States
{
    public class FiniteStateMachine : FiniteStateMachine<object>
    {
    }

    public class FiniteStateMachine<T>
    {
        protected IState<T> currentState;
        private Dictionary<Type, IState<T>> typeDict;
        private Dictionary<string, IState<T>> stringDict;
        public T owner { get; set; }

        public FiniteStateMachine() 
        {
            typeDict = new Dictionary<Type, IState<T>>();
        }

        public FiniteStateMachine(T owner = default)
        {
            this.owner = owner;
            typeDict = new Dictionary<Type, IState<T>>();
        }

        public void AddState(IState<T> state)
        {
            typeDict.Add(state.GetType(), state);
            state.fsm = this;
        }


        public void AddStateWithName(string stateName, IState<T> state)
        {
            stringDict.Add(stateName, state);
        }

        public void ChangeStateByName(string name)
        {
            // if find a state with name "name", change to it.
            if (stringDict.ContainsKey(name))
                ChangeToState(stringDict[name]);
            else
                Debug.Log($"Can't find {name}");
        }

        virtual public void ChangeStateByType<U>()
        {
            // find state by T
            var t = typeof(U);
            if (typeDict.ContainsKey(t))
                ChangeToState(typeDict[t]);
            else
                Debug.Log($"Can't find {t}");
        }

        virtual public void ChangeToState(IState<T> newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
        }

        virtual public void Update(float dt)
        {
            currentState?.Update(dt);
        }

        public IState<T> CurrentState { get { return currentState; } }

        public bool IsStateType<U>() => currentState is U;
    }
}