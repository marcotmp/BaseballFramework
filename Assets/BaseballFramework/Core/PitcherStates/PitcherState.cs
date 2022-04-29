using MarcoTMP.BaseballFramework.Core.States;


namespace MarcoTMP.BaseballFramework.Core.PitcherStates
{
    public class PitcherState : StateBase<BFPitcher>
    {
        public const string Pitching = "Pitching";
        public const string Thinking = "Thinking";

        public BFPitcher pitcher => fsm.owner;
    }
}
