#if HE_SYSCORE
using System;
using UnityEngine;

namespace HeathenEngineering.Serializable
{
    [Obsolete("Use Unity's Mathmatics.float3")]
    [Serializable]
    public class SerializableVector3 : SerializableVector2
    {
        public float z;

        public SerializableVector3() : base() { }

        public SerializableVector3(SerializableVector3 copyFrom)
        {
            x = copyFrom.x;
            y = copyFrom.y;
            z = copyFrom.z;
        }

        public SerializableVector3(Vector3 value)
        {
            x = value.x;
            y = value.y;
            z = value.z;
        }

        public SerializableVector3(float x, float y, float z) : base(x, y)
        {
            this.z = z;
        }

        public static implicit operator Vector3(SerializableVector3 value)
        {
            return new Vector3(value.x, value.y, value.z);
        }

        public static implicit operator SerializableVector3(Vector3 value)
        {
            return new SerializableVector3() { x = value.x, y = value.y, z = value.z };
        }
    }
}
#endif