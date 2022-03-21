#if HE_SYSCORE
using System;
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering.Serializable
{
    [Serializable]
    public class SerializableRectTransform : SerializableTransform
    {
        public float2 anchorMax;
        public float2 anchorMin;
        public float2 pivot;

        public SerializableRectTransform() : base()
        {
            anchorMax = new float2(0.5f, 0.5f);
            anchorMin = new float2(0.5f, 0.5f);
            pivot = new float2(0.5f, 0.5f);
        }

        public SerializableRectTransform(Transform transform) : base(transform)
        {
            anchorMax = new float2(0.5f, 0.5f);
            anchorMin = new float2(0.5f, 0.5f);
            pivot = new float2(0.5f, 0.5f);
        }

        public SerializableRectTransform(RectTransform rectTransform) : base(rectTransform)
        {
            anchorMax = new float2(rectTransform.anchorMax);
            anchorMin = new float2(rectTransform.anchorMin);
            pivot = new float2(rectTransform.pivot);
        }

        public SerializableRectTransform(float3 position, quaternion rotation, float3 localScale, float2 anchorMin, float2 anchorMax, float2 pivot) : base(position, rotation, localScale)
        {
            anchorMax = new float2(anchorMax);
            anchorMin = new float2(anchorMin);
            pivot = new float2(pivot);
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
#endif