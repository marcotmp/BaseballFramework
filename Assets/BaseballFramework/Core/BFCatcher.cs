using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcoTMP.BaseballFramework.Core
{
    public class BFCatcher
    {
        public Action OnBallCatched { get; set; }

        public void CatchBall()
        {
            OnBallCatched?.Invoke();
        }
    }
}
