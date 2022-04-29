using MarcoTMP.BaseballFramework.Core;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 1;
    private BFBall ball;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.moveTo == "Home")
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
    }

    public void ConnectActor(BFBall ballActor)
    {
        this.ball = ballActor;
        ball.onReset = OnReset;
    }

    private void OnReset()
    {
        ball.moveTo = "";
        transform.position = startPosition;
    }
}
