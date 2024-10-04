#if HE_SYSCORE
using System;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Float Game Event Listener")]
    public class FloatGameEventListener : GameEventListener<float>
    {
        public FloatGameEvent Event;
        public UnityFloatDataEvent Response;
        public UnityFloatEvent UnityEvent;

        [Obsolete("Please use Response")]
        public UnityFloatDataEvent Responce => Response;

        public override IGameEvent<float> m_event => Event;

        public override UnityDataEvent<float> m_response => Response;

        public override UnityEvent<float> m_unityEvent => UnityEvent;
    }
}
#endif