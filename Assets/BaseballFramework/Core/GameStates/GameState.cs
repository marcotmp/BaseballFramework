using MarcoTMP.BaseballFramework.Core;
using MarcoTMP.BaseballFramework.Core.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcoTMP.BaseballFramework.Core.GameStates
{
    public class GameState : StateBase<BFGame>
    {
        public BFGame game
        {
            get => fsm.owner;
            set { fsm.owner = value; }
        }
    }
}
