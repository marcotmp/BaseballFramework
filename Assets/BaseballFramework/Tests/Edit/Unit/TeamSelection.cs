using MarcoTMP.BaseballFramework.Core;
using NUnit.Framework;
using System.Collections;
using UnityEngine;

namespace Assets.BaseballFramework.Tests.Edit.Unit
{
    public class TeamSelection 
    {

        [Test]
        public void Select1Player()
        {
            // Given a 1player game
            var game = new BFGame();
            game.Select1PlayerMode();

            // When player select a team
            game.SelectHomeTeam("Aguilas");

            // Then the team is selected
            Assert.AreEqual("Aguilas", game.competitors.home.team);
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
    
}