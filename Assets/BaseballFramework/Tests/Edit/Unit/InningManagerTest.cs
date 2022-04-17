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
        public void DeffensiveAndOffensiveChangeWhenHalfInningComplete()
        {
            innings.CompleteHalf();

            Assert.AreEqual(visitor.team, innings.ofensive.team);
            Assert.AreEqual(home.team, innings.defensive.team);
        }

        [Test]
        public void GameHas9Innings()
        {
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

        [Test]
        public void FirstHalfDoesntCompleteInning()
        {
            bool inningCompleted = false;
            innings.half = Half.FirstHalf;
            innings.OnInningComplete = () => {
                inningCompleted = true;
            };
            innings.CompleteHalf();

            Assert.IsFalse(inningCompleted, "Should not complete inning");
        }

        [Test]
        public void SecondHalfCompleteInning()
        {
            bool inningCompleted = false;
            innings.half = Half.SecondHalf;
            innings.OnInningComplete = () => {
                inningCompleted = true;
            };
            innings.CompleteHalf();

            Assert.IsTrue(inningCompleted, "Should complete inning");
        }
    }
}
