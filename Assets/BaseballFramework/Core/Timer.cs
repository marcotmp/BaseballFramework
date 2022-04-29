using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcoTMP.BaseballFramework.Core
{
    public class Timer
    {
        public float duration = 1;
        public float timeElapsed { get; private set; } = 0;

        public bool Tick(float dt)
        {
            timeElapsed += dt;
            return timeElapsed >= duration;
        }

        public void Reset(float duration)
        {
            timeElapsed = 0;
            this.duration = duration;
        }
    }
}
