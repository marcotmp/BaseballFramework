using MarcoTMP.BaseballFramework.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.BaseballFramework.Tests.Edit.Unit
{
    public class InningManagerTest
    {
        private InningsManager innings;
        private CompetingTeam home;
        private CompetingTeam visitor;
        [SetUp]
        public void Setup()
        {
            innings = new InningsManager();
            home = new CompetingTeam { team = "Aguilas" };
            visitor = new CompetingTeam { team = "Licey" };
            innings.ofensive = home;
            innings.defensive = visitor;
        }

        [Test]
        public void DeffensiveAndOffensiveChangeWhenInningComplete()
        {
            innings.ofensive = new CompetingTeam { team = "Aguilas" };
            innings.defensive = new CompetingTeam { team = "Licey" }; 

            innings.CompleteInning();

            Assert.AreEqual("Licey", innings.ofensive.team);
            Assert.AreEqual("Aguilas", innings.defensive.team);
        }

        [Test]
        public void PlayerWin()
        {
            // given
            innings.inning = 9;
            innings.ofensive.runs = 5;
            innings.defensive.runs = 4;

            // when
            innings.CompleteInning();

            // then
            Assert.AreEqual("Aguilas", innings.winner);
        }

        [Test]
        public void PlayerLose()
        {
            innings.inning = 9;
            innings.ofensive.runs = 5;
            innings.defensive.runs = 4;

            innings.CompleteInning();

            Assert.AreEqual(innings.ofensive.team, innings.winner);
        }

        [Test]
        public void ExtraInning()
        {
            innings.inning = 9;
            innings.ofensive.runs = 5;
            innings.defensive.runs = 5;
            innings.maxInnings = 100;

            innings.CompleteInning();

            Assert.AreEqual("", innings.winner);
            Assert.AreEqual(10, innings.inning);
        }

        [Test]
        public void EndOfInningDoesNotResultInWinOrLose()
        {
            innings.inning = 8;
            innings.ofensive.runs = 5;
            innings.defensive.runs = 4;

            innings.CompleteInning();

            Assert.AreEqual("", innings.winner, "should not win");
            Assert.AreEqual(9, innings.inning);
        }

        [Test]
        public void ExtraInningWin()
        {
            innings.inning = 10;
            innings.ofensive.runs = 5;
            innings.defensive.runs = 4;

            innings.CompleteInning();

            Assert.AreEqual(innings.ofensive.team, innings.winner);
        }

        [Test]
        public void ExtraInningLose()
        {
            innings.inning = 10;
            innings.ofensive.runs = 4;
            innings.defensive.runs = 5;

            innings.CompleteInning();

            Assert.AreEqual(innings.defensive.team, innings.winner);
        }

        [Test]
        public void MaxEtraInningsEndTheGame()
        {
            innings.maxInnings = 10;
            innings.inning = 10;
            innings.ofensive.runs = 5;
            innings.defensive.runs = 5;

            innings.CompleteInning();

            Assert.AreEqual("Empate", innings.winner);
            Assert.AreEqual(10, innings.inning);
        }
    }

    public class InningsManager
    {
        public int inning;
        internal int finalInning = 9;

        public CompetingTeam ofensive;
        public CompetingTeam defensive;
        public string winner;
        internal int maxInnings = 9;

        internal void CompleteInning()
        {
            if (inning >= finalInning)
            {
                // check draw
                if (ofensive.runs == defensive.runs)
                {
                    if (inning < maxInnings)
                    {
                        winner = "";
                        inning++; // extra inning
                    }
                    else
                        winner = "Empate";
                }
                else if (ofensive.runs > defensive.runs)
                    winner = ofensive.team;
                else
                    winner = defensive.team;
            }
            else
            {
                inning++;
                winner = "";
                CompleteHalf();
            }
        }

        public void CompleteHalf()
        {
            CompetingTeam tmpOfensive = ofensive;
            ofensive = defensive;
            defensive = tmpOfensive;
        }
    }
}
