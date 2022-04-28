using MarcoTMP.BaseballFramework.Core.PitcherStates;

namespace MarcoTMP.BaseballFramework.Core.PitcherStates.AI
{
    public class AIPitcherPitchingState : PitcherState
    {
        public override void Enter()
        {
            base.Enter();

            pitcher.OnStartPitchingAnim?.Invoke();
        }

        public override void Update(float dt)
        {
            base.Update(dt);

        }
    }
}