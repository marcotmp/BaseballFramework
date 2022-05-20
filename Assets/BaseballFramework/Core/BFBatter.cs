using MarcoTMP.BaseballFramework.Core.BatterStates;
using MarcoTMP.BaseballFramework.Core.States;
using System;
using UnityEngine;

namespace MarcoTMP.BaseballFramework.Core
{
    public class BFBatter
    {
        // Batter States
        /*
        HumanIdle
        HumanMove
        HumanSwing

        AIIdle        
        AIMove
        AISwing
        */


        public Action startSwingAnimation;
        public Action<Vector3> onMove;
        public bool isActive;
        private FiniteStateMachine<BFBatter> fsm;

        public Action OnDeadBall;
        public Action OnHit;
        internal bool didSwing;

        public BFBatter()
        {
            //FiniteStateMachine<BFBatter> humanBrain;
            //FiniteStateMachine<BFBatter> AIBrain;

            // var batterBrain = CreateHumanBatterBrain();
            // var batterBrain = CreateAIBatterBrain();
            // var batterBrain = currentTeam.GetBatterBrain();
        }

        public virtual void Init()
        {
            throw new NotImplementedException();
        }

        virtual public void Activate()
        {
        }

        public void Enable()
        {
            isActive = true;
        }

        internal void Disable()
        {
            isActive = false;
        }

        public void SetBrain(FiniteStateMachine<BFBatter> fsm)
        {
            this.fsm = fsm;
            fsm.owner = this;
        }

        virtual public void Update(float dt)
        {
            fsm?.Update(dt);
        }


        virtual public void DoSwing()
        {
            startSwingAnimation?.Invoke();
        }

        public void SwingAnimationComplete()
        {
        }
    }
}