
using System;
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
        public SerializableVector3 position;
        public SerializableQuaternion rotation;
        public SerializableVector3 localScale;

        public SerializableTransform()
        {
            position = new SerializableVector3();
            rotation = new SerializableQuaternion();
            localScale = new SerializableVector3(1,1,1);
        }

        public SerializableTransform(SerializableVector3 position, SerializableQuaternion rotation, SerializableVector3 localScale)
        {
            this.position = new SerializableVector3(position);
            this.rotation = new SerializableQuaternion(rotation);
            this.localScale = new SerializableVector3(localScale);
        }

        public SerializableTransform(Transform transform)
        {
            this.position = new SerializableVector3(transform.position);
            this.rotation = new SerializableQuaternion(transform.rotation);
            this.localScale = new SerializableVector3(transform.localScale);
        }

        public SerializableTransform(Vector3 position, Quaternion rotation, Vector3 localScale)
        {
            this.position = new SerializableVector3(position);
            this.rotation = new SerializableQuaternion(rotation);
            this.localScale = new SerializableVector3(localScale);
        }

        public void SetTransform(Transform transform)
        {
            transform.position = new Vector3(position.x, position.y, position.z);
            transform.rotation = new Quaternion(rotation.x, rotation.y, rotation.z, rotation.w);
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        }

        public static implicit operator SerializableTransform(Transform value)
        {
            return new SerializableTransform() { position = value.position, rotation = value.rotation, localScale = value.localScale };
        }
    }
}
