using MarcoTMP.BaseballFramework.Core;
using MarcoTMP.BaseballFramework.Core.BatterStates.Human;
using MarcoTMP.BaseballFramework.Core.BatterStates;
using MarcoTMP.BaseballFramework.Core.States;
using UnityEngine;
using MarcoTMP.BaseballFramework.Core.PitcherStates.AI;
using MarcoTMP.BaseballFramework.Core.GameStates;

public class GameManager : MonoBehaviour, IGameListener
{
    [Header("Game Elements")]
    public Pitcher pitcher;
    public Batter batter;
    public Ball ball;

    [Header("Bases")]
    public Catcher catcher;

    [Header("Messages")]
    public GameObject strike;

    public InputController input;

    private BFGame game;

    // Start is called before the first frame update
    void Start()
    {
        // create an AI Pitcher 
        var _pitcher = new BFPitcher();
        var pitcherBrain = new FiniteStateMachine<BFPitcher>();
        //pitcherBrain.AddState(new AIPitcherIdleState());
        pitcherBrain.AddState(new AIPitcherThinkingState());
        pitcherBrain.AddState(new AIPitcherPitchingState());        
        pitcherBrain.ChangeStateByType<AIPitcherThinkingState>();
        _pitcher.SetBrain(pitcherBrain);

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

        game = new BFGame();
        game.pitcherActor = _pitcher;
        game.batterActor = _batter;
        game.ballActor = _ball;
        game.catcherActor = _catcher;

        // game states
        var gameFSM = new FiniteStateMachine<BFGame>();
        var battingAndPitchingState = new BattingAndPitchingState(); 
        battingAndPitchingState.pitchingRules = game;
        gameFSM.AddState(battingAndPitchingState);

        var strikeState = new StrikeState();
        gameFSM.AddState(strikeState);
        game.SetFSM(gameFSM);

        game.defaultState = battingAndPitchingState;

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
        input.ConnectInput(game.player1InputController);


        //game.SetState(GameState.BattingAndPitching);

        // when catcher get the ball, notify game that ball touched home
        catcher.ConnectActor(game.catcherActor);
        //catcher.onBallCatched = () => game.BallTouchHome();

        game.SetListener(this);

        game.Start();
    }

    // Update is called once per frame
    void Update()
    {
        game.Update(Time.deltaTime);
    }

    // IGameListener
    public void ShowStrikeMessage()
    {
        strike.SetActive(true);
    }

    private FiniteStateMachine<BFBatter> GetHumanBatterBrain(BFInputController input)
    {
        var fsm = new FiniteStateMachine<BFBatter>();
        fsm.AddState(new HumanIdle(input));
        fsm.AddState(new HumanMove());
        fsm.AddState(new BatterSwing());
        return fsm;
    }
}
