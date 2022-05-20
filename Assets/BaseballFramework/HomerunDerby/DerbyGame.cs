using MarcoTMP.BaseballFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MarcoTMP.BaseballFramework.HomerunDerby
{
    public class DerbyGame
    {
        public BFPitcher pitcher;
        public BFBatter batter;
        public BFBall ball;
        public BFCatcher catcher;
        public DerbyTimer timer;
        public IMessage message;
        public DerbyScoreboard scoreboard;

        public void Init()
        {
            batter.Init();
            pitcher.Init();
            timer.Init();

            catcher.OnBallCatched = ActivateBattingAndPitching;

            ball.onLandOnHomerun = DoHomerun;

            pitcher.Activate();
            batter.Activate();
        }

        private void ActivateBattingAndPitching() {
            // on ball catched, activate pitcher / batter
            pitcher.Activate();
            batter.Activate();
        }

        public void ProcessHit()
        {
            ball.MoveTo(Vector3.zero);
        }

        private void DoHomerun()
        {
            scoreboard.homerun++;
            float seconds = 3;
            message.Show(seconds, ActivateBattingAndPitching);
        }

        public void Update(float deltaTime)
        {
        }
    }
}
