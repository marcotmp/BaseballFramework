using MarcoTMP.BaseballFramework.Core;
using System;
using UnityEngine;

public class Catcher : MonoBehaviour
{
    [SerializeField] private Ball ball;

    //public Action onBallCatched;
    private BFCatcher actor;

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.z < transform.position.z)
        {
            // notify ball is catched
            //onBallCatched?.Invoke();
            actor.OnBallCatched?.Invoke();
        }
    }

    public void ConnectActor(BFCatcher catcherActor)
    {
        this.actor = catcherActor;
    }
}
