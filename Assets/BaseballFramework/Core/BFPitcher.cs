using MarcoTMP.BaseballFramework.Core.PitcherStates;
using MarcoTMP.BaseballFramework.Core.States;
using System;
using UnityEngine;

namespace MarcoTMP.BaseballFramework.Core
{
    public class BFPitcher
    {
        public string state = "IDLE";
        public Action OnStartPitchingAnim { get; set; }
        public Action DoThinkingAnimation { get; set; }
        public Action onGrabBall;
        public Action onReleaseBall;
        public bool isActive;
        public Func<float> GetDuration = ()=> UnityEngine.Random.Range(1, 5);
        
        private FiniteStateMachine<BFPitcher> fsm;
        private Timer timer = new Timer();

        internal void Enable()
        {
            isActive = true;

            // set default state
            fsm.SetDefaultState();
        }

        internal void Disable()
        {
            isActive = false;
        }

        virtual public void Init()
        {
            throw new NotImplementedException();
        }

        virtual public void Update(float dt)
        {
            fsm.Update(dt);
        }

        virtual public void Activate()
        {
        }

        public void ThinkingAnimation()
        {
            DoThinkingAnimation?.Invoke();
        }

        public void StartPitching()
        {
            Think();
        }

        public void Think()
        {
            state = "THINK";
            timer.duration = GetDuration();
        }

        public void SetBrain(FiniteStateMachine<BFPitcher> pitcherBrain)
        {
            fsm = pitcherBrain;
            fsm.owner = this;
        }

        public void AnimationCompleted()
        {
            state = "PITCHING";
        }

        /// <summary>
        /// Must be called when the animation frame is the right one to release the ball
        /// </summary>
        public void ReleaseBall()
        {
            onReleaseBall?.Invoke();
        }
    }

    #region HumanStates
    public class HumanActiveState
    {
        public void Enter() { }
        public void Update() 
        {
            // press B -> pitch
            // dPad left / right -> move left / right
        }
        public void Exit() { }
    }
    public class PitchState
    {
        public void Enter() { }
        public void Update() { }
        public void Exit() { }
    }
    #endregion HumanStates

    #region AIStates
    public class AIIdleState // wait a few seconds
    {
        public void Enter() { }
        public void Update() { }
        public void Exit() { }
    }
    public class AIThink // pick throw type -> move -> throw
    {
        public void Enter() { }
        public void Update() 
        {
            // random move -> move and stay in this state
            // random pitch -> change to pitch state
        }
        public void Exit() { }
    }
    
    #endregion AIStates
}
