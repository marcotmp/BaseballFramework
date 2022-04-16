using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MarcoTMP.BaseballFramework.Core
{
    public class AIPitcherController : IPitcherController
    {
        public string state = "IDLE";
        private Timer timer = new Timer();

        public Action StartAnimation { get; set; }

        public void Think()
        {
            state = "THINK";
        }

        public void Update(float dt)
        {
            Debug.Log(state);
            if (state == "THINK")
            {
                bool isDone = timer.Tick(dt);
                if (isDone)
                {
                    state = "PITCHING";
                    StartAnimation?.Invoke();
                }
            }
        }

        public void AnimationCompleted()
        {
            state = "PITCHING";
        }

        public void StartPitching()
        {
        }
    }
}
