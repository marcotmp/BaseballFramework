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
        public string state = "IDLE";
        public Action OnStartPitchingAnim { get; set; }
        private Timer timer = new Timer();
        public Action onReleaseBall;

        virtual public void Update(float dt)
        {
            //controller.Update(dt);
            if (state == "THINK")
            {
                bool isDone = timer.Tick(dt);
                if (isDone)
                {
                    state = "PITCHING";
                    OnStartPitchingAnim?.Invoke();
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

        /// <summary>
        /// Must be called when the animation frame is the right one to release the ball
        /// </summary>
        public void ReleaseBall()
        {
            onReleaseBall?.Invoke();
        }
    }
}
