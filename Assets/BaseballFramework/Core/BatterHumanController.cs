using System;
using UnityEngine;

namespace MarcoTMP.BaseballFramework.Core
{
    public interface IBatterController
    {
        
    }

    public class BatterHumanController : IBatterController
    {
        public BFInputController inputController;
        private BFBatter batter;

        public BatterHumanController(BFInputController inputController) 
        {
            this.inputController = inputController;
        }

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

        public void Update(float dt)
        {
            var a = inputController.buttonA;
        }
    }
}
