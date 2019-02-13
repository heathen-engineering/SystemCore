using System;
using UnityEngine;

namespace HeathenEngineering.Serializable
{
    /// <summary>
    /// Binary serializable bridge for UnityEngine.RectTransform
    /// </summary>
    /// <remarks>
    /// Derived from and convertable from SerializableTransform
    /// </remarks>
    [Serializable]
    public class SerializableRectTransform : SerializableTransform
    {
        public SerializableVector2 anchorMax;
        public SerializableVector2 anchorMin;
        public SerializableVector2 pivot;

        public SerializableRectTransform() : base()
        {
            anchorMax = new SerializableVector2(0.5f, 0.5f);
            anchorMin = new SerializableVector2(0.5f, 0.5f);
            pivot = new SerializableVector2(0.5f, 0.5f);
        }

        public SerializableRectTransform(Transform transform) : base(transform)
        {
            anchorMax = new SerializableVector2(0.5f, 0.5f);
            anchorMin = new SerializableVector2(0.5f, 0.5f);
            pivot = new SerializableVector2(0.5f, 0.5f);
        }

        public SerializableRectTransform(RectTransform rectTransform) : base(rectTransform)
        {
            anchorMax = new SerializableVector2(rectTransform.anchorMax);
            anchorMin = new SerializableVector2(rectTransform.anchorMin);
            pivot = new SerializableVector2(rectTransform.pivot);
        }

        public SerializableRectTransform(Vector3 position, Quaternion rotation, Vector3 localScale, Vector2 anchorMin, Vector2 anchorMax, Vector2 pivot) : base(position, rotation, localScale)
        {
            anchorMax = new SerializableVector2(anchorMax);
            anchorMin = new SerializableVector2(anchorMin);
            pivot = new SerializableVector2(pivot);
        }

        public static implicit operator SerializableRectTransform(RectTransform value)
        {
            return new SerializableRectTransform()
            {
                position = value.position,
                rotation = value.rotation,
                localScale = value.localScale,
                anchorMin = value.anchorMin,
                anchorMax = value.anchorMax,
                pivot = value.pivot
            };
        }
    }
}
