using MarcoTMP.BaseballFramework.Core.GameStates;
using MarcoTMP.BaseballFramework.Core.States;
using System;
using UnityEngine;

namespace MarcoTMP.BaseballFramework.Core
{
    public enum GameStateEnum
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
        void HandleBattingAndPitching(float dt);
        bool CheckIsBall();
        bool CheckIsHit();
        bool CheckStealBase();

        bool IsStrike { get; set; }
    }

    public class BFGame : IPitchingRules // 9InningBasballSimulation
    {
        public static Func<FiniteStateMachine<BFGame>> FSMFactory = ()=> default(FiniteStateMachine<BFGame>);
        public GameStateEnum state = GameStateEnum.BattingAndPitching;
        public BFPitcher pitcherActor;
        public BFBatter batterActor;
        public BFBall ballActor;
        public BFCatcher catcherActor;
        public InningsManager innings;


        public Competitors competitors;
        private IGameListener listener;
        public BFInputController player1InputController = new BFInputController();
        
        public FiniteStateMachine<BFGame> fsm { get; private set; }
        public bool IsStrike { get; set; } = false;
        public GameStates.GameState defaultState;
        public ProcessPitch processPitch;

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
            state = GameStateEnum.BattingAndPitching;

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


        public void SetListener(IGameListener listener)
        {
            this.listener = listener;
        }

        public void InitPitching()
        {
            batterActor.Enable();
            pitcherActor.Enable();

            ballActor.ResetPosition();

            IsStrike = false;

            // this might go into batting and pitching state
            // or in the game.SetPitcherActor(pitcherActor);
            pitcherActor.onReleaseBall = () =>
            {
                ballActor.MoveTo("Home");
            };

            //catcherActor.OnBallCatched = () =>
            //{
            //    IsStrike = true;

            //    // anota strike al equipo ofensivo
            //    // inningBoard.strike++;
            //    // dispatch que hubo un strike

            //};
        }

        public void FinishPitching()
        {
            batterActor.Disable();
            pitcherActor.Disable();
        }

        public bool CheckIsStrikeOut()
        {
            return false;
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

        virtual public void ShowStrikeMessage()
        {
            listener.ShowStrikeMessage();
        }

        virtual public void HideStrikeMessage()
        {
            listener.HideStrikeMessage();
        }

    }

    public interface IGameListener
    {
        void HideStrikeMessage();
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

    public class HalfInningBoard
    {
        public int strikes;
        public int balls;
        public int foul;
        public int outs;

        public void Reset()
        {
            strikes = 0;
            balls = 0;
            foul = 0;
            outs = 0;
        }

    }

}