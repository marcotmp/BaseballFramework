using MarcoTMP.BaseballFramework.Core.GameStates;
using MarcoTMP.BaseballFramework.Core.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcoTMP.BaseballFramework.Core.GameStates
{
    public class StrikeOutState : GameState
    {
        public override void Enter()
        {
            base.Enter();

            // if out, show out message
            //game.processPitch.result.@out

            // if change
            if (game.processPitch.result.endOfHalf)
            {
                // game change half
                fsm.ChangeStateByType<BattingAndPitchingState>();
            }
        }
    }
}
