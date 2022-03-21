#if HE_SYSCORE
using System;
using UnityEngine;

namespace HeathenEngineering.Serializable
{
    [Obsolete("Use Unity's Mathmatics.int2")]
    [Serializable]
    public class SerializableVector2Int
    {
        public int x;
        public int y;

        public SerializableVector2Int() { }

        public SerializableVector2Int(SerializableVector2Int copyFrom)
        {
            x = copyFrom.x;
            y = copyFrom.y;
        }

        public SerializableVector2Int(Vector2Int value)
        {
            x = value.x;
            y = value.y;
        }

        public SerializableVector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static implicit operator Vector2Int(SerializableVector2Int value)
        {
            return new Vector2Int(value.x, value.y);
        }

        public static implicit operator SerializableVector2Int(Vector2Int value)
        {
            return new SerializableVector2Int() { x = value.x, y = value.y };
        }
    }
}
#endif