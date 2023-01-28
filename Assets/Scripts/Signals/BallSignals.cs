using Enums;
using Extentions;
using System;
using System.Collections.Generic;
using UnityEngine.Events;
using Controllers;

namespace Signals
{
    public class BallSignals : MonoSingleton<BallSignals>
    {
        public UnityAction onIncreaseBallCount = delegate { };
        public UnityAction<BallMovementController>  onAddToLooseCheck = delegate { };
        public UnityAction onBallInTheCup = delegate { };
        public UnityAction OnColorlessBallOnCup = delegate { };
    }
}