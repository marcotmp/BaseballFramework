using NUnit.Framework;

public class GameTest
{
    [Test]
    public void OnStartGame_ShowMenuAnimation()
    {
    }

    public class Select1P
    {
        [Test]
        public void OnSelect1P_Select1Player()
        {
            // when player select 1P -> set game in 1P Mode
        }

        [Test]
        public void OnSelect1P_OpenSelectYourTeam()
        {
            // when player select 2P -> open select your team
        }
    }

    public class Select2P
    {
        [Test]
        public void OnSelect2P_Select2PlayersMode()
        {
            // when player select 2P -> set game in 2P Mode
        }

        [Test]
        public void OnSelect2P_OpenSelectYourTeam()
        {
            // when player select 2P -> open select your team
        }
    }

    [Test]
    public void OnTeamSelected_OpenSelectYourPitcher()
    {
    }

    [Test]
    public void OnPitcherSelected_OpenStatsScene()
    {
    }

    [Test]
    public void AfterStatsSceneDelay_StartBatView()
    {
        // Display bat view
        // Enable batter
        // Enable input controller
        // Enable pitcher
    }
}
