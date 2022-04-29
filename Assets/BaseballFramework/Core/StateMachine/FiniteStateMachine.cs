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
        private IState<T> initialState;

        public T owner { get; set; }

        public FiniteStateMachine() 
        {
            typeDict = new Dictionary<Type, IState<T>>();
            stringDict = new Dictionary<string, IState <T>>();

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


        public void AddState(string stateName, IState<T> state)
        {
            stringDict.Add(stateName, state);
            typeDict.Add(state.GetType(), state);
            state.fsm = this;
        }

        public void ChangeStateByName(string name)
        {
            // if find a state with name "name", change to it.
            if (stringDict.ContainsKey(name))
                ChangeToState(stringDict[name]);
            else
                Debug.Log($"Can't find {name}");
        }

        public void SetInitialState(string name)
        {
            if (stringDict.ContainsKey(name))
            initialState = stringDict[name];
        }

        public void SetDefaultState()
        {
            ChangeToState(initialState);
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
            //Debug.Log($"new state {newState}");
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