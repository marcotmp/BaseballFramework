using MarcoTMP.BaseballFramework.Core.GameStates;


namespace MarcoTMP.BaseballFramework.HomerunDerby
{
    public class DerbyBattingState : GameState
    {
        public override void Enter()
        {
            base.Enter();
            // start pitcher
            // start batter
            // start timer
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            // if hit... fly state
            // if catch... repeat state
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

/*
# Derby:
start pitcher
start batter
start timer

# PitchingAndBatting:
batter active
pitcher active { onPitch: deactivate }

catcher: catch the ball -> activate batter/pitcher
batter: hit the ball -> ball fly

ball: land on field -> {
    show distance for 2 seconds
    : if timer = 0: end derby
    else reset batter/pitcher
}
ball: land out of field -> homerun

Homerun:{
    show homerun message for a few seconds
    then back to # pitching and batting
    : if timer = 0: end derby
}
*/
