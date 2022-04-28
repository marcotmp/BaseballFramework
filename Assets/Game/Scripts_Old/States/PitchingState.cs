using Baseball;
using MarcoTMP.BaseballFramework.Core;
using MarcoTMP.BaseballFramework.Core.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballState : MonoBehaviour//, IState
{
    public virtual void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }

    public void Update(float dt)
    {
        throw new System.NotImplementedException();
    }
}

public class PitchingState : BaseballState
{
   // private GameController game;
    private BFBatter batter;

    //public PitchingState(GameController game)
    //{
    //    this.game = game;
    //}

    

    // this state is the first state of the game

    public override void Enter()
    {
        // set front view
        //game.SetPitchingView();
        // enable pitcher
        // enable bat
        //batter.Enable();

        // allow base stealing... if offensive steals, change to FlyHitState
    }

    public void Exit()
    {
    }

    public void Update()
    {
        // if ball position is at catcher
        // do strike or strike-out

        // if bat hit the ball -> FlyHitState
    }
}
