using System;

namespace MarcoTMP.BaseballFramework.Core
{
    public enum GameState
    {
        RunningAndCatching,
        BattingAndPitching
    }

    public class BFGame // 9InningBasballSimulation
    {
        public GameState state = GameState.BattingAndPitching;
        public BFPitcher pitcherActor;
        public BFBatter batterActor;
        public BFBall ballActor;



        public Competitors competitors;

        public void Update(float deltaTime)
        {
            pitcherActor.Update(deltaTime);
            batterActor.Update(deltaTime);
        }

        public void Select1PlayerMode()
        {
            competitors.home = new CompetingTeam { type = CompetingType.Human };
            competitors.visitor = new CompetingTeam { type = CompetingType.AI };
        }

        public void SelectHomeTeam(string teamName)
        {
            competitors.home.team = teamName;
        }

        public void Select2PlayersMode()
        {
            competitors.home = new CompetingTeam { type = CompetingType.Human };
            competitors.visitor = new CompetingTeam { type = CompetingType.Human };
        }
    }

    public enum CompetingType
    {
        AI,
        Human
    }

    public struct Competitors
    {
        public CompetingTeam home;
        public CompetingTeam visitor;
    }

    public class CompetingTeam
    {
        public CompetingType type = CompetingType.Human;
        public string team = "";
        public int runs = 0;
    }

}