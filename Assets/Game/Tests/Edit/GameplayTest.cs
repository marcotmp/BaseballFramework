using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameplayTest
{

    [Test]
    public void When_ShowGameplay()
    {

    }

    [Test]
    public void WhenPitcherFinishSwing_BallIsOut() { }

    [Test]
    public void WhenPlayerMoveX_BatMoveX() { }

    // Bat
    [Test]
    public void WhenBatTouchBall_ChangeToHitState() { }

    // Runner
    [Test]
    public void WhenStartHitState_BatRunsTo1stBase() { }

    [Test]
    public void WhenRunnerReach1stBase_RunnerStop() { }

    // Ball
    [Test]
    public void WhenHit_Fly() { }

    [Test]
    public void WhenHitGround_Rebound() { }

    [Test]
    public void WhenBallHitWall_Rebound() { }

    // Runner
    [Test]
    public void WhenRunnerGetHome_AnnotateRun() { }



    [Test]
    public void OnBatHit_EnterFlyState()
    {

    }
}
