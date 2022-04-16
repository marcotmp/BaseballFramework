using MarcoTMP.BaseballFramework.Core;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Pitcher pitcher;
    public Batter batter;
    public Ball ball;
    private BFGame game;

    // Start is called before the first frame update
    void Start()
    {
        // create an AI Pitcher 
        var _pitcher = new BFPitcher();
        //_pitcher.SetController(new AIPitcherController());
        var _batter = new BFBatter();
        var _ball = new BFBall();

        game = new BFGame();
        game.pitcherActor = _pitcher;
        game.batterActor = _batter;
        game.ballActor = _ball;

        // setup teams
        game.Select1PlayerMode();

        //_pitcher = game.currentHalf.GetPitcher();
        //_batter = game.currentHalf.GetBatter();

        // connect baseball framework with unity scene elements
        pitcher.SetBFPitcher(game.pitcherActor);
        batter.SetBatterActor(game.batterActor);
        //batter.onAnim = ()=> { game.batterActor.ReturnBall(); };
        //game.batterActor.OnStartSwing = batter.DoSwing;
        ball.ConnectActor(game.ballActor);

        _pitcher.StartPitching();
    }

    // Update is called once per frame
    void Update()
    {
        game.Update(Time.deltaTime);
    }
}
