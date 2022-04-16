using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcoTMP.BaseballFramework.Core
{
    public interface IPitcherController
    {
        void Update(float dt);
        void StartPitching();
    }
}
