#if HE_SYSCORE
using System;
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering.Serializable
{
    /// <summary>
    /// Binary serializable bridge with UnityEngine.Transform
    /// </summary>
    /// <remarks>
    /// Leverages SerializableVector3 and SerializableQuaternion to store position, rotation and localScale
    /// </remarks>
    [Serializable]
    public class SerializableTransform
    {
        public float3 position;
        public quaternion rotation;
        public float3 localScale;

        public SerializableTransform()
        {
            position = new float3();
            rotation = new quaternion();
            localScale = new float3(1,1,1);
        }

        public SerializableTransform(float3 position, quaternion rotation, float3 localScale)
        {
            this.position = position;
            this.rotation = rotation;
            this.localScale = localScale;
        }

        public SerializableTransform(Transform transform)
        {
            this.position = transform.position;
            this.rotation = transform.rotation;
            this.localScale = transform.localScale;
        }

        public SerializableTransform(Vector3 position, Quaternion rotation, Vector3 localScale)
        {
            this.position = position;
            this.rotation = rotation;
            this.localScale = localScale;
        }

        public void SetTransform(Transform transform)
        {
            transform.position = position;
            transform.rotation = rotation;
            transform.localScale = localScale;
        }

        public static implicit operator SerializableTransform(Transform value)
        {
            return new SerializableTransform() { position = value.position, rotation = value.rotation, localScale = value.localScale };
        }
    }
}
#endif