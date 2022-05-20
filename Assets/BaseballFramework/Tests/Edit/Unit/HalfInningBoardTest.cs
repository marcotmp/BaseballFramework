using MarcoTMP.BaseballFramework.Core;
using MarcoTMP.BaseballFramework.Core.GameStates;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.BaseballFramework.Tests.Edit.Unit.HalfInning
{
    class HalfInningBoardTest
    {
        /*
        when catcher catch the ball => {    
            if (ball pass over batter square => ball++
            if ball > 2, ball = 2; // maybe ball is also a strike?
            if (strike < 3)
            {
                strike++
                notify strike
            }
            else
            {
                strike = 0
                out++;
            }
        }

        when batter hit the ball => change to running and fielding



        */
        [Test]
        public void TestStrike()
        {
            HalfInningBoard board = new HalfInningBoard();

            // when strike
            board.strikes++;

            // when 3 strikes => it's an out
            board.strikes = 2;

            // when 3 outs, it's a change
            // and reset the board


        }

        
    }

    public class Game
    {
        public int strikes;
        public int balls;
        public int outs;

        public int runs;

        public Action onStrike;

        private Catcher catcher;

        public void Init()
        {
            // this is only processed in the batting and pitching state
            catcher.CatchTheBall += () =>
            {
                // process strikes...
                //if (ball pass over batter square => ball++
                if (balls > 2)
                    balls = 2; // maybe ball is also a strike?

                if (strikes < 3)
                {
                    strikes++;
                    onStrike?.Invoke();
                    // update UI
                    // set strike state
                }
                else
                {
                    strikes = 0;
                    outs++;
                    // update UI
                    // set strike out state
                    // then change half
                }
            };

            //batter.WasHit = () =>
            //{
            //    deball++;
            //};
        }
    }

    public class Catcher
    {
        public bool hasTheBall = false;

        public event Action CatchTheBall;
    }


    public class UmpierTest
    {
        public void StrikeTest()
        {
            var catcher = new Catcher();
            var umpire = new Umpire();

            // when catcher has the ball
            catcher.hasTheBall = true;

            umpire.Update(0);

            // then umpire result in strike
            //Assert.AreEqual(CatchResult.Strike, umpire.catchResult);
        }
    }

    public class Batter
    {
        public event Action HitTheBall;
    }

    public class Umpire
    {
        public CatchResult catchResult;
        public Catcher catcher;
        public HalfInningBoard board;
        public Action onStrike;
        public Action onOut;
        public Action onEndOfHalf;

        public Batter batter;

        public void Init()
        {
            catcher.CatchTheBall += OnCatcherCatchTheBall;
            batter.HitTheBall += OnBatterHitTheBall;
        }

        private void OnBatterHitTheBall()
        {

        }

        private void OnCatcherCatchTheBall()
        {
            // Variables:
            // on the left
            // on the right
            // on the center
            // batter swung the bat

            bool onBatterZone = false;
            bool batterSwung = false;

            if (batterSwung)
            {
                catchResult.strike = true;
            }
            else
            {
                if (onBatterZone)
                    catchResult.ball = true;
                else
                    catchResult.strike = true;
            }

            if (catchResult.strike)
            {
                ProcessStrike();
            }

        }

        private void ProcessStrike()
        { 
            // if catch in center => strike
            // if catch in bat zone => ball
            board.strikes++;
            if (board.strikes > 3)
            {
                board.strikes = 0;

                // process outs
                board.outs++;
                if (board.outs > 3)
                {
                    // result out and end of halg
                    onEndOfHalf?.Invoke();
                    // Do strike => out => onChange
                }
                else
                {
                    // result strike out
                    onOut?.Invoke();
                    // Do strike => out
                }
            }
            else
            {
                // result just strike
                onStrike?.Invoke();
                // Do strike
            }
        }

        public void Reset()
        {
            catchResult.Clear();
        }

        internal void Update(int v)
        {

        }
    }

    public class CatchResult
    {
        public bool ball;
        public bool strike;
        public bool @out;

        internal void Clear()
        {
            ball = false;
            strike = false;
            @out = false;
        }
    }


    public enum PitchingResult
    {

    }


    public class ShowMessages : GameState
    {
        public Umpire umpire;
        public HalfInningBoard board;
        public override void Enter()
        {
            base.Enter();

            // if faul => show foul
            // if strike => show strike
            // if out => show out
            // if change => change
        }
    }

}
