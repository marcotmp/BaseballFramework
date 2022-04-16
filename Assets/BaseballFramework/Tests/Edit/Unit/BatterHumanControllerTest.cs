using MarcoTMP.BaseballFramework.Core;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.BaseballFramework.Tests.Edit.Unit
{
    class BatterHumanControllerTest
    {
        [Test]
        public void DoSwing()
        {
            var batter = Substitute.For<BFBatter>();

            var batterHumanController = new BatterHumanController();
            batterHumanController.SetBatter(batter);
            //batter.startSwingAnimation = () => isSwinging = true;

            // when
            batterHumanController.PressBat();

            // then batter bat is called
            batter.Received().DoSwing();
        }
    }
}
