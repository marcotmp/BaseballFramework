using MarcoTMP.BaseballFramework.Core;
using MarcoTMP.BaseballFramework.Core.BatterStates.Human;
using MarcoTMP.BaseballFramework.Core.BatterStates;
using MarcoTMP.BaseballFramework.Core.States;
using UnityEngine;
using MarcoTMP.BaseballFramework.Core.PitcherStates.AI;
using MarcoTMP.BaseballFramework.Core.GameStates;
using MarcoTMP.BaseballFramework.Core.PitcherStates;
using MarcoTMP.BaseballFramework.HomerunDerby;

public class HomerunDerbyManager : MonoBehaviour
{
    [Header("Game Elements")]
    public Pitcher pitcher;
    public Batter batter;
    public Ball ball;

    [Header("Bases")]
    public Catcher catcher;

    [Header("Messages")]
    public GameObject hit;
    public GameObject homerun;

    public InputController input;

    private DerbyGame game;

    // Start is called before the first frame update
    void Start()
    {
        // Setup batter
        var _batter = new BFBatter();
        var inputController = new BFInputController();
        var batterBrain = new FiniteStateMachine<BFBatter>();
        batterBrain.AddState(new HumanIdle(inputController));
        batterBrain.AddState(new HumanMove());
        batterBrain.AddState(new HumanSwing());
        //var batterBrain = GetHumanBatterBrain(inputController);
        _batter.SetBrain(batterBrain);
        batterBrain.ChangeStateByType<HumanIdle>();


        var _ball = new BFBall();
        var _catcher = new BFCatcher();
        var _pitcher = CreateAIPitcher();

        game = new DerbyGame();
        game.pitcher = _pitcher;
        game.batter = _batter;
        game.ball = _ball;
        game.catcher = _catcher;
        //game.player1InputController = inputController;

        // connect baseball framework with unity scene elements
        pitcher.SetBFPitcher(game.pitcher);
        batter.SetBatterActor(game.batter);
        ball.ConnectActor(game.ball);
        //input.ConnectInput(game.player1InputController);

        // when catcher get the ball, notify game that ball touched home
        catcher.ConnectActor(game.catcher);

        game.Init();
    }

    // Update is called once per frame
    void Update()
    {
        game.Update(Time.deltaTime);
    }


    public BFPitcher CreateAIPitcher()
    {
        var _pitcher = new BFPitcher();
        var pitcherBrain = new FiniteStateMachine<BFPitcher>();

        pitcherBrain.AddState(PitcherState.Thinking, new AIPitcherThinkingState());
        pitcherBrain.AddState(PitcherState.Pitching, new AIPitcherPitchingState());
        pitcherBrain.SetInitialState(PitcherState.Thinking);

        _pitcher.SetBrain(pitcherBrain);

        return _pitcher;
    }
}
