#if HE_SYSCORE
using System;
using UnityEngine;

namespace HeathenEngineering.Serializable
{
    [Obsolete("Use Unity's Color")]
    [Serializable]
    public class SerializableColor : SerializableVector4
    {
        public float r
        {
            get { return x; }
            set { x = value; }
        }

        public float g
        {
            get { return y; }
            set { y = value; }
        }

        public float b
        {
            get { return z; }
            set { z = value; }
        }

        public float a
        {
            get { return w; }
            set { w = value; }
        }

        public SerializableColor() : base() { r = 1; g = 1; b = 1; a = 1; }

        public SerializableColor(Color color)
        {
            x = color.r;
            y = color.g;
            z = color.b;
            w = color.a;
        }

        public SerializableVector4 ToHSVA()
        {
            float h, s, v;
            RGBToHSV(this, out h, out s, out v);
            return new SerializableVector4() { x = h, y = s, z = v, w = a };
        }

        public SerializableVector3 ToHSV()
        {
            float h, s, v;
            RGBToHSV(this, out h, out s, out v);
            return new SerializableVector3() { x = h, y = s, z = v };
        }

        public static implicit operator Color(SerializableColor value)
        {
            return new Color(value.x, value.y, value.z, value.w);
        }

        public static implicit operator SerializableColor(Color value)
        {
            return new SerializableColor() { x = value.r, y = value.g, z = value.b, w = value.a };
        }

        public static void RGBToHSV(Color color, out float h, out float s, out float v)
        {
            Color.RGBToHSV(color, out h, out s, out v);
        }

        public static SerializableColor HSVtoRGB(float h, float s, float v, float a = 1, bool hdr = false)
        {
            SerializableColor c = Color.HSVToRGB(h, s, v, hdr);

            if (hdr)
                return c;
            else
            {
                c.w = a;
                return c;
            }
        }
    }
}
#endif