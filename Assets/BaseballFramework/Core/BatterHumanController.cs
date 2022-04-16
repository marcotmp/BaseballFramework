using System;
using UnityEngine;

namespace MarcoTMP.BaseballFramework.Core
{
    public interface IBatterController
    {
        
    }

    public class BatterHumanController : IBatterController
    {
        private BFBatter batter;

        public void MoveAxis(Vector3 vector3)
        {
            throw new NotImplementedException();
        }

        public void PressBat()
        {
            batter.DoSwing();
        }

        public void SetBatter(BFBatter batter)
        {
            this.batter = batter;
        }
    }
}
