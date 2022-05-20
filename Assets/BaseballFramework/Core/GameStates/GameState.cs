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

/*
# Baseball - 9 inning game
- set score in zero
- game stats [0,0,0,0,0,0,0,0,0] <- 9 innings

ProcessChange: {
    ChangeBatter
    ChangeHalve
    ChangeInning
}

# BattingAndPitching
    show half inning stats {runs, strikes, outs}

    activate batter {
        on swing {
            do animation
        }
    }
    activate pitcher {
        on pitch: ball moves
    }

    catcher: catch ball -> {
        strike
        strikeout
        ball
    }

    batter: catch ball {
        dead ball
    }

    batter: hit the ball {
        ball start moving up, down, left or right 
        -> change camera
        -> start moving fielders
        -> start running
    }

    StrikeOut: {
        show out for 2 seconds
        Process Out {change batter, half or inning}
    }

# RunningAndFielding {
    Ball: out of field {
        show homerun fanfare for n deconds
        auto move all runners into each base
    }
    Ball: foul zone { foul }

    Fielder: Move to catch the flyball
    Fielder: catch fly ball { FlyOut }
    Fielder: grab ball { grab ball }
    Fielder: shoot ball { ball move to a base fielder }
    Fielder: catch fielder ball { 
        if runner already in base, safe
    }
    Runner: get to a base {
        if fielder has ball, out
    }
    Runner: get to a home {
        if fielder has ball, out
        else, score a run and show info on screen with a fanfare
    }

    FlyOut: {
        show out for 2 seconds
        Process Out {change batter / change half / change inning}
    }
}

*/
