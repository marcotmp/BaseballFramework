using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inning : MonoBehaviour
{
    public Frame top;
    public Frame bottom;
}


public class InningManager
{
    // 9 innings
    // a [][][][][][][][][]
    // b [][][][][][][][][]

    public void Start() { }

    public void Out()
    {
        // change from a to b team
        // or change to next inning

        // if no more innings, end game
    }
}

public class Frame
{
    // game elements
    // team offensive
    // team defensive
    // ball

    public void Enter()
    {
        //bat.active
        //pitcher.pitch
    }

    public void Update()
    {
        // PitchingState
        // FlyHitState
    }

}


/*

if (strike == 3)
{
    out ++
    if (out == 3)
    {
        change frame
    }
}

*/
