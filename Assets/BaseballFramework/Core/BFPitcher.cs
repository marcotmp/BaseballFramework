using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MarcoTMP.BaseballFramework.Core
{
    public class BFPitcher
    {
        public Action OnStartPitchingAnim { get; set; }
        public string state = "IDLE";
        public Action StartAnimation { get; set; }
        private Timer timer = new Timer();

        virtual public void Update(float dt)
        {
            //controller.Update(dt);
            if (state == "THINK")
            {
                bool isDone = timer.Tick(dt);
                if (isDone)
                {
                    state = "PITCHING";
                    StartAnimation?.Invoke();
                }
            }
            Debug.Log(state);
        }

        public void StartPitching()
        {
            Think();
        }

        public void Think()
        {
            state = "THINK";
            timer.duration = 1;
        }

        public void AnimationCompleted()
        {
            state = "PITCHING";
        }

    }
}
