#if HE_SYSCORE
using System;
using UnityEngine;

namespace HeathenEngineering.Serializable
{
    [Obsolete("Use Unity's Mathmatics.quaternion")]
    [Serializable]
    public class SerializableQuaternion : SerializableVector4
    {
        public SerializableQuaternion() : base() { }

        public SerializableQuaternion(SerializableVector4 copyFrom) : base(copyFrom)
        {
        }

        public SerializableQuaternion(SerializableQuaternion copyFrom) : base()
        {
            x = copyFrom.x;
            y = copyFrom.y;
            z = copyFrom.z;
            w = copyFrom.w;
        }

        public SerializableQuaternion(float x, float y, float z, float w) : base(x, y, z, w)
        {
        }

        public SerializableQuaternion(Quaternion value)
        {
            x = value.x;
            y = value.y;
            z = value.z;
            w = value.w;
        }

        public static implicit operator SerializableQuaternion(Quaternion value)
        {
            return new SerializableQuaternion() { x = value.x, y = value.y, z = value.z, w = value.w };
        }
    }
}
#endif