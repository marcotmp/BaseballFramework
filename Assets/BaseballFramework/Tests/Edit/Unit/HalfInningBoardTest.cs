using MarcoTMP.BaseballFramework.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.BaseballFramework.Tests.Edit.Unit
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
            catcher.CatchTheBall = () =>
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
        public Action CatchTheBall { get; internal set; }
    }
}
