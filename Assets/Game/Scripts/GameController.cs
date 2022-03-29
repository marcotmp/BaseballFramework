using MarcoTmp.States;
using UnityEngine;

namespace Baseball
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Pitcher pitcher;
        [SerializeField] private Ball ball;
        [SerializeField] private Batter batter;

        // game participants
        public Team teamA;
        public Team teamB;

        // elements during gameplay
        public Team offensive;
        public Team deffensive;

        // game score
        public int teamAScore;
        public int teamBScore;
        public int _out;
        public int strikes;

        //public InningManager inningManager;

        public FiniteStateMachine fsm;
        public IState gameState;

        // Start is called before the first frame update
        void Start()
        {
            //inningManager.Start();
            // set state PitchingState()
            // 

            fsm = new FiniteStateMachine();
            //fsm.AddState(new PitchingState());

            fsm.ChangeStateByType<PitchingState>();
        }

        // Update is called once per frame
        void Update()
        {
            fsm.Update();
        }

        public void Out()
        {
            // if top of inning, swap teams, DoStep
            //if (innings.isTopOfInning)
            // if bottom of inning, change to next inning, DoStep
            //if (innings.isBottomOfInning)
            // if no more innings, end game
            //if (innings.noMoreInnings)
        }

    }

    public class Team
    {
        // offensive members
        public Batter batter;
        public Pitcher pitcher;
        public Runner[] runner1 = new Runner[4];

        // deffensive members
        public Fielder catcher;
        public Fielder firstBase;
        public Fielder secondBase;
        public Fielder thirdBase;
        public Fielder shortStop;
        public Fielder leftField;
        public Fielder centerField;
        public Fielder rightField;
    }

    public class Runner { }
    public class Fielder { }
}