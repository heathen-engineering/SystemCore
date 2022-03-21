#if HE_SYSCORE
using System;
using UnityEngine;

namespace HeathenEngineering.Serializable
{
    [Obsolete("Use Unity's Mathmatics.float2", true)]
    [Serializable]
    public class SerializableVector2
    {
        public float x;
        public float y;

        public SerializableVector2() { }

        public SerializableVector2(SerializableVector2 copyFrom)
        {
            x = copyFrom.x;
            y = copyFrom.y;
        }

        public SerializableVector2(Vector2 value)
        {
            x = value.x;
            y = value.y;
        }

        public SerializableVector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static implicit operator Vector2(SerializableVector2 value)
        {
            return new Vector2(value.x, value.y);
        }

        public static implicit operator SerializableVector2(Vector2 value)
        {
            return new SerializableVector2() { x = value.x, y = value.y };
        }
    }
}
#endif