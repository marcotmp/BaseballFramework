using MarcoTMP.BaseballFramework.Core.States;


namespace MarcoTMP.BaseballFramework.Core.PitcherStates
{
    public class PitcherState : StateBase<BFPitcher>
    {
        public BFPitcher pitcher => fsm.owner;
    }
}
