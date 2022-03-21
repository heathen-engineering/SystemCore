#if HE_SYSCORE
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Float Game Event Listener")]
    public class FloatGameEventListener : GameEventListener<float>
    {
        public FloatGameEvent Event;
        public UnityFloatDataEvent Responce;
        public UnityFloatEvent UnityEvent;

        public override IGameEvent<float> m_event => Event;

        public override UnityDataEvent<float> m_responce => Responce;

        public override UnityEvent<float> m_unityEvent => UnityEvent;
    }
}
#endif