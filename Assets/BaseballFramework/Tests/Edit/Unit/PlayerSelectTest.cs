using MarcoTMP.BaseballFramework.Core;
using NUnit.Framework;

namespace Assets.BaseballFramework.Tests.Edit.Unit
{
    public class PlayerSelectTest
    {
        [Test]
        public void Select1Player()
        {
            // Given a game
            var game = new BFGame();
            
            // When player select 1 player mode
            game.Select1PlayerMode();

            // Then Team A is player
            Assert.AreEqual(CompetingType.Human, game.competitors.home.type);
            
            // And AI is assigned to the oponent team
            Assert.AreEqual(CompetingType.AI, game.competitors.visitor.type);
        }

        [Test]
        public void Select2Players()
        {
            var game = new BFGame();

            // When player select 1 player
            game.Select2PlayersMode();

            // Then Team Home is player
            Assert.AreEqual(CompetingType.Human, game.competitors.home.type);

            // Then Team Visitor is player
            Assert.AreEqual(CompetingType.Human, game.competitors.visitor.type);
        }
    }

}