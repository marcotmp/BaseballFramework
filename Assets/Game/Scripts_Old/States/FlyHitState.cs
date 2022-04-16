using Baseball;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyHitState : MonoBehaviour
{
    public GameController game;
    private void Enter()
    {
        // set top view
        //game.SetTopView();
        // allow fielders to move and catch the ball
        //game.AllowFieldersToMove();
        // allow batter to move to a save plate
        //game.AllowBatterToMove();
    }

    private void Update()
    {   
        // update fielders movement from assigned input;
        // update offensive movement from assigned input;

        // if any runner reach home, show "run" message and increase score
    }
}