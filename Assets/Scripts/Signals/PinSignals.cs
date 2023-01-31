using Enums;
using Extentions;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Signals
{
    public class PinSignals : MonoSingleton<PinSignals>
    {
        public UnityAction onPinHasPulled = delegate { };
    }
}