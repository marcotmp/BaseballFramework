using MarcoTMP.BaseballFramework.Core;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 1;
    private BFBall ball;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.moveTo == "Home")
        {
            Debug.Log(ball.moveTo);
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
    }

    public void ConnectActor(BFBall ballActor)
    {
        this.ball = ballActor;
    }
}
