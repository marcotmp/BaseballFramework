using MarcoTMP.BaseballFramework.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.BaseballFramework.Tests.Edit.Unit
{
    public class BFBallTest
    {
        [Test]
        public void BallMove()
        {
            var ball = new BFBall();
            ball.MoveTo("Home");
            Assert.AreEqual("Home", ball.moveTo, $"Should move to {ball.moveTo}");
        }            
    }
}
