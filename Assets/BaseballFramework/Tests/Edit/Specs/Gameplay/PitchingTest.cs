using NUnit.Framework;
using System;

namespace Assets.Game.Tests.Edit.Spec.Gameplay
{
	public class PitchingTest
	{
		[Test]
		public void PitchingResultInStrike()
        {
            var game = new Game();
            var pitcher = new Pitcher();
            var ball = new Ball();
            var ampayer = new Ampayer();

            game.ball = ball;
            game.pitcher = pitcher;

            //Given pitcher is ready to pitch
            pitcher.isReady = true;

            //When game is in pitching state
            game.SetState("Pitching");

            //Then pitcher pick lanzamiento
            Assert.AreEqual(pitcher.GetPitchStrategy(), "Rect");

            //When thingking for x seconds
            pitcher.Update(3);

            //Then inicia anim lanzamiento
            pitcher.OnStartPitchingAnim();//.WasCalled;

            //When pitcher in frame de lanzamiento
            pitcher.ReleaseBall();

            //Then pelota inicia movimiento hacia home
            ball.MoveTo("Home");//.WasCalled();

            //When pelota toca al home
            game.Touch(ball, game.bases.home);

            //Then ampayer canta strike
            ampayer.Say("Strike");//.WasCalled();
        }
	}

    public class Game
    {
        internal Bases bases;
        internal Ball ball;
        internal Pitcher pitcher;

        public Game()
        {
            pitcher.onReleaseBall = () => {
                ball.MoveTo("Home");
            };
        }

        internal void SetState(string v)
        {
            if (v == "Pitching")
                pitcher.StartPitching();
        }

        internal void Touch(Ball ball, object home)
        {
            throw new NotImplementedException();
        }
    }

    public class Pitcher
    {
        internal bool isReady;
        public string GetPitchStrategy() 
        {
            return "Rect";
        }

        internal void ReleaseBall()
        {
            onReleaseBall?.Invoke();
        }

        public Action OnStartPitchingAnim;
        internal Action onReleaseBall;

        internal void Update(object timeElapsed)
        {
            throw new NotImplementedException();
        }

        internal void StartPitching()
        {
            throw new NotImplementedException();
        }
    }

    public class Ball
    {
        internal object MoveTo(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class Ampayer
    {
        internal void Say(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class Bases
    {
        public string home;
    }

}