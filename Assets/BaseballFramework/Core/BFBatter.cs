using System;
using System.Collections;
using UnityEngine;

namespace MarcoTMP.BaseballFramework.Core
{
    public class BFBatter
    {
        public Action startSwingAnimation;
        public Action<Vector3> onMove;

        virtual public void DoSwing()
        {
        }

        public void SetController(object aiBatterController)
        {
            throw new NotImplementedException();
        }

        virtual public void Update(float dt)
        {

        }
    }
}