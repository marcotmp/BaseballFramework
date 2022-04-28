using MarcoTMP.BaseballFramework.Core.GameStates;
using MarcoTMP.BaseballFramework.Core.States;
using System;
using UnityEngine;

namespace MarcoTMP.BaseballFramework.Core
{
    public enum GameState
    {
        RunningAndCatching,
        BattingAndPitching,
        Strike
    }
    public interface IPitchingRules
    {
        void InitPitching();
        void FinishPitching();
        bool CheckIsStrikeOut();
        bool CheckIsStrike();
        void HandleBattingAndPitching(float dt);
        bool CheckIsBall();
        bool CheckIsHit();
        bool CheckStealBase();
    }

    public class BFGame : IPitchingRules // 9InningBasballSimulation
    {
        public static Func<FiniteStateMachine<BFGame>> FSMFactory = ()=> default(FiniteStateMachine<BFGame>);
        public GameState state = GameState.BattingAndPitching;
        public BFPitcher pitcherActor;
        public BFBatter batterActor;
        public BFBall ballActor;
        public BFCatcher catcherActor;
        public InningsManager innings;


        public Competitors competitors;
        private IGameListener listener;
        public BFInputController player1InputController = new BFInputController();
        
        public FiniteStateMachine<BFGame> fsm { get; private set; }

        public BFGame()
        {
            fsm = FSMFactory();
        }



        public void SetFSM(FiniteStateMachine<BFGame> fsm)
        {
            this.fsm = fsm;
            fsm.owner = this;
        }

        public void Update(float deltaTime)
        {
            fsm.Update(deltaTime);

            //pitcherActor.Update(deltaTime);
            //batterActor.Update(deltaTime);

            //if (ballActor touch home) change to Strike
            //innings.CompleteHalf();
        }

        public void Start()
        {
            //fsm.ChangeStateByType<BattingAndPitchingState>();
            fsm.ChangeToState(defaultState);
            state = GameState.BattingAndPitching;

            // if catcher get the ball
            // catcher.onBallCatched = () => BallTouchHome();


        }

        public void Select1PlayerMode()
        {
            competitors.home = new CompetingTeam { type = CompetingType.Human };
            competitors.visitor = new CompetingTeam { type = CompetingType.AI };
        }

        public void SelectHomeTeam(string teamName)
        {
            competitors.home.team = teamName;
        }

        public void Select2PlayersMode()
        {
            competitors.home = new CompetingTeam { type = CompetingType.Human };
            competitors.visitor = new CompetingTeam { type = CompetingType.Human };
        }

        [Obsolete]
        public void SetState(GameState newState)
        {
            this.state = newState;

            if (newState == GameState.Strike)
            {
                listener?.ShowStrikeMessage();
            }
            else
            {
                pitcherActor.onReleaseBall = () =>
                {
                    ballActor.MoveTo("Home");
                };
                pitcherActor.StartPitching();
            }
        }

        public void BallTouchHome()
        {
            isStrike = true;
            // select strike or strikeout
            //fsm.ChangeStateByType<StrikeState>();
            SetState(GameState.Strike);
            
        }

        public void SetListener(IGameListener listener)
        {
            this.listener = listener;
        }

        public void InitPitching()
        {
            batterActor.Enable();
            pitcherActor.Enable();

            isStrike = false;

            // this might go into batting and pitching state
            pitcherActor.onReleaseBall = () =>
            {
                ballActor.MoveTo("Home");
            };

            catcherActor.OnBallCatched = () =>
            {
                isStrike = true;
            };
        }

        public void FinishPitching()
        {
            batterActor.Disable();
            pitcherActor.Disable();
        }

        private bool isStrike = false;
        public GameStates.GameState defaultState;

        public bool CheckIsStrikeOut()
        {
            return false;
        }

        public bool CheckIsStrike()
        {
            return isStrike;
        }

        public void HandleBattingAndPitching(float dt)
        {
            batterActor.Update(dt);
            pitcherActor.Update(dt);
        }

        public bool CheckIsBall()
        {
            return false;
        }

        public bool CheckIsHit()
        {
            return false;
        }

        public bool CheckStealBase()
        {
            return false;
        }
    }

    public interface IGameListener
    {
        void ShowStrikeMessage();
    }


    public enum CompetingType
    {
        AI,
        Human
    }

    public struct Competitors
    {
        public CompetingTeam home;
        public CompetingTeam visitor;
    }

    public class CompetingTeam
    {
        public CompetingType type = CompetingType.Human;
        public string team = "";
        public int runs = 0;
    }

}