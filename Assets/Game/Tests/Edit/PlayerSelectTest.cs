using NUnit.Framework;

namespace Entytec.Baseball.Test
{
    public class PlayerSelectTest
    {
        [Test]
        public void Select1Player()
        {
            var game = new Game();

            // Given player is not selected
            game.players = 0;
            
            // When player select 1 player
            game.Select1PlayerMode();

            // Then Team A is player
            Assert.IsTrue(game.team1.isPlayer);

            // And AI is assigned to the oponent team
            Assert.IsTrue(game.team2.isAI);
        }

        [Test]
        public void Select2Players()
        {
            var game = new Game();

            // Given player is not selected
            game.players = 0;

            // When player select 1 player
            game.Select2PlayersMode();

            // Then Team A is player
            Assert.IsTrue(game.team1.isPlayer);

            // And Team B is player
            Assert.IsTrue(game.team2.isPlayer);
        }
    }

    public class Game
    {
        internal int players;

        public Team team1 = new Team();
        public Team team2 = new Team();

        internal void Select1PlayerMode()
        {
            team1.isPlayer = true;
            team2.isAI = true;
        }

        internal void Select2PlayersMode()
        {
            team1.isPlayer = true;
            team2.isPlayer = true;
        }
    }

    public class Team
    {
        public bool isPlayer = false;
        public bool isAI = false;
    }
}