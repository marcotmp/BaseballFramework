using NUnit.Framework;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Tests.Edit
{
    public class TeamSelection 
    {

        [Test]
        public void Select1Player()
        {
            var game = new Game();
            // Given no team is selected by player
            game.teamSelected =null;

            // When player select a team

            // Then the team is selected
        }

        [Test]
        public void DisplayListOfTeams()
        {
            // given game has registered a list of teams
            //game.listOfTeams = listOfTeams;

            // When teams are requestes
            //var teams = Game.GetListOfTeams();
            
            // then the list of teams is displayed
            //teams == listOfTeams;
        }
    }

    public class Game
    {
        internal string teamSelected;
    }
}