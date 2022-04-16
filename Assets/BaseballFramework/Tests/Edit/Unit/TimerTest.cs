using MarcoTMP.BaseballFramework.Core;
using NUnit.Framework;

namespace Assets.BaseballFramework.Tests.Edit.Unit
{
    public class TimerTest
    {
        // Timer, Wait, Reset
        [Test]
        public void Wait()
        {
            var timer = new Timer();
            timer.duration = 1;

            Assert.AreEqual(0, timer.timeElapsed, "timeElapsed should be zero");

            bool isDone = timer.Tick(0.5f);
            Assert.IsFalse(isDone, "should not finish after 0.5s");

            isDone = timer.Tick(0.5f);
            Assert.AreEqual(1, timer.timeElapsed, "time elapsed should be 1s");
            Assert.IsTrue(isDone, "should finish after 1s");

            timer.Reset(2);

            isDone = timer.Tick(1f);
            Assert.IsFalse(isDone, $"should not finish when duration is {timer.duration}");

            isDone = timer.Tick(1f);
            Assert.IsTrue(isDone, $"should finish after timeElapsed {timer.timeElapsed}");

        }
    }

}
