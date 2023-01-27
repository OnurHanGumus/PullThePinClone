using Enums;
using Extentions;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Signals
{
    public class BallSignals : MonoSingleton<BallSignals>
    {
        public UnityAction onIncreaseBallCount = delegate { };
        public UnityAction onBallInTheCup = delegate { };
    }
}