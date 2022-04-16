using MarcoTMP.BaseballFramework.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitcher : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private BFPitcher pitcher;

    internal void SetBFPitcher(BFPitcher pitcher)
    {
        this.pitcher = pitcher;
        pitcher.OnStartPitchingAnim = () => {
            animator.SetTrigger("Pitching");
        };
    }

    public void Anim_OnDropBall()
    {
        // when anim is in the right frame, release the ball
        //pitcher.DropBall();
    }

    public void Anim_OnPitchCompleted()
    {
        // when pitching anim is completed, return to IDLE
    }

}
