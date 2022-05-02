using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.BaseballFramework.Tests.Edit.Specs.Gameplay
{
    class BattingAndPitchingFeature_Reactive
    {
        // Pitching result in a strike
        // Pitching result in a ball
        // Pitching result in a dead ball
        // Pitching result in a hit

        public void TestRectStrike()
        {
            // Given game is in BattingAndPitching
            // And pitcher throws a rect ball
            // When catcher catches the ball
            // Then show strike message

            // game = CreateGameInState(new BattingAndPitching());
            // pitcher.Throw("rect");
            // catcher.CatchBall();
            // game.Received().ShowStrike();
        }

        public void TestCurveStrike()
        {
            // Given game is in BattingAndPitching
            // And pitcher throws a curve ball
            // And batter swing the bat
            // When catcher catches the ball
            // Then show strike message
        }




        public void TestStrikeOutChangeBatter()
        {
            // Given game is in BattingAndPitching
            // And pitcher throws a rect ball
            // And board is strikes=2
            // When catcher catches the ball
            // Then show strike message
            // When 2 seconds has passed
            // Then show out message
            // When 2 seconds has passed
            // Then Change batter and back to BattingAndPitching
        }

        public void TestStrikeOutChangeHalf()
        {
            // Given game is in BattingAndPitching
            // And pitcher throws a rect ball
            // And board is strikes=2
            // And board is out=2
            // When catcher catches the ball
            // Then show strike message
            // When 2 seconds has passed
            // Then show out message
            // When 2 seconds has passed
            // Then Show change half 
        }



        public void TestBall()
        {
            // Given game is in BattingAndPitching
            // And pitcher throws a curve ball
            // And batter didn't swing the bat
            // When catcher catches the ball
            // Then show ball message
        }

        public void TestDeadBall()
        {
            // Given game is in BattingAndPitching
            // And pitcher throws a curve ball
            // When ball touches batter
            // Then show DeadBall message
        }

        public void TestHit()
        {
            // Given game is in BattingAndPitching
            // And pitcher throws a rect ball
            // And batter swing the bat
            // When bat touches the ball
            // Then change to running and fielding
        }
    }

    public class Catcher { }
}
