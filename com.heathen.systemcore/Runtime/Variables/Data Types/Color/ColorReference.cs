#if HE_SYSCORE
using HeathenEngineering.Serializable;
using System;
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering
{
    [Serializable]
    public class ColorReference : VariableReference<float4>
    {
        public ColorVariable Variable;
        public override IDataVariable<float4> m_variable => Variable;

        public ColorReference(float4 value) : base(value)
        { }

        public ColorReference(Color value) : base((Vector4)value)
        { }
    }
}
#endif