using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Tests.Edit.Specs.Gameplay
{
    public class PlayerWinsTest
    {
        private Game game;

        [SetUp]
        public void Init()
        {
            game = new Game();
        }

        [Test]
        public void PlayerWin()
        {
            // given
            game.inning = 9;
            game.teamARuns = 5;
            game.teamBRuns = 4;

            // when
            game.CompleteInning();

            // then
            Assert.AreEqual("teamA", game.winner); 
        }

        [Test]
        public void PlayerLose()
        {
            game.inning = 9;
            game.teamARuns = 4;
            game.teamBRuns = 5;

            game.CompleteInning();

            Assert.AreEqual("teamB", game.winner);
        }

        [Test]
        public void ExtraInning()
        {
            game.inning = 9;
            game.teamARuns = 5;
            game.teamBRuns = 5;

            game.CompleteInning();

            Assert.AreEqual("", game.winner);
            Assert.AreEqual(10, game.inning);
        }

        [Test]
        public void EndOfInningDoesNotResultInWinOrLose()
        {
            game.inning = 8;
            game.teamARuns = 5;
            game.teamBRuns = 4;

            game.CompleteInning();

            Assert.AreEqual("", game.winner, "should not win");
            Assert.AreEqual(9, game.inning);
        }

        [Test]
        public void ExtraInningWin()
        {
            game.inning = 10;
            game.teamARuns = 5;
            game.teamBRuns = 4;

            game.CompleteInning();

            Assert.AreEqual("teamA", game.winner);
        }

        [Test]
        public void ExtraInningLose()
        {
            game.inning = 10;
            game.teamARuns = 4;
            game.teamBRuns = 5;

            game.CompleteInning();

            Assert.AreEqual("teamB", game.winner);
        }

        [Test]
        public void MaxEtraInningsEndTheGame()
        {
            game.maxInnings = 10;
            game.inning = 10;
            game.teamARuns = 5;
            game.teamBRuns = 5;

            game.CompleteInning();

            Assert.AreEqual("Empate", game.winner);
            Assert.AreEqual(10, game.inning);
        }

    }

    public class Game
    {
        internal int inning;
        internal int teamARuns;
        internal int teamBRuns;
        internal string winner="";
        internal int maxInnings = 10;
        internal int finalInning = 9;

        internal void CompleteInning()
        {
            if (inning >= finalInning)
            {
                // check draw
                if (teamARuns == teamBRuns)
                {
                    if (inning < maxInnings)
                    {
                        winner = "";
                        inning++; // extra inning
                    }
                    else
                        winner = "Empate";
                }
                else if (teamARuns > teamBRuns)
                    winner = "teamA";
                else
                    winner = "teamB";
            }
            else
            {
                inning++;
            }
        }
    }
}