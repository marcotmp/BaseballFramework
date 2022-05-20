using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MarcoTMP.BaseballFramework.Core
{
    public class BFBall
    {
        public Action onReset;
        public string moveTo;

        public Action onLandOnHomerun { get; internal set; }

        public void MoveTo(string where)
        {
            moveTo = where;
        }
        virtual public void MoveTo(Vector3 dir)
        {
        }

        internal void ResetPosition()
        {
            onReset?.Invoke();
        }

        public void LandOnHomerun()
        {
            onLandOnHomerun?.Invoke();
        }
    }
}
