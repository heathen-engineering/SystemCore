#if HE_SYSCORE
using System;
using UnityEngine;

namespace HeathenEngineering.Serializable
{
    [Obsolete("Use Unity's Mathmatics.float4")]
    [Serializable]
    public class SerializableVector4 : SerializableVector3
    {
        public float w;

        public SerializableVector4() : base() { }

        public SerializableVector4(SerializableVector4 copyFrom)
        {
            x = copyFrom.x;
            y = copyFrom.y;
            z = copyFrom.z;
            w = copyFrom.w;
        }

        public SerializableVector4(Vector4 value)
        {
            x = value.x;
            y = value.y;
            z = value.z;
            w = value.w;
        }

        public SerializableVector4(float x, float y, float z, float w) : base(x, y, z)
        {
            this.w = w;
        }

        public static implicit operator Vector4(SerializableVector4 value)
        {
            return new Vector4(value.x, value.y, value.z, value.w);
        }

        public static implicit operator SerializableVector4(Vector4 value)
        {
            return new SerializableVector4() { x = value.x, y = value.y, z = value.z, w = value.w };
        }
    }
}
#endif