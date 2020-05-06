﻿using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Float Game Event Listener")]
    public class FloatGameEventListener : GameEventListener<float>
    {
        public FloatGameEvent Event;
        public UnityFloatDataEvent Responce;

        public override IGameEvent<float> m_event => Event;

        public override UnityDataEvent<float> m_responce => Responce;
    }
}
