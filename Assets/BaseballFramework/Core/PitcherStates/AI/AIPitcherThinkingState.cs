using System;

namespace MarcoTMP.BaseballFramework.Core.PitcherStates.AI
{
    public class AIPitcherThinkingState : PitcherState
    {
        public Func<float> GetDelayTime = () => UnityEngine.Random.Range(1, 5);
        private Timer timer;

        public AIPitcherThinkingState()
        {
            timer = new Timer();
        }
        
        public override void Enter()
        {
            base.Enter();
            timer.Reset(GetDelayTime());
            pitcher.ThinkingAnimation();
        }
        
        public override void Update(float dt)
        {
            base.Update(dt);

            if (timer.Tick(dt))
                fsm.ChangeStateByName(PitcherState.Pitching);
        }
    }
}
