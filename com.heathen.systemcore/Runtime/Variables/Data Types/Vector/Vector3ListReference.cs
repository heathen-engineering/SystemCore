#if HE_SYSCORE
using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace HeathenEngineering
{
    [Serializable]
    public class Vector3ListReference : VariableReference<List<float3>>
    {
        public Vector3ListVariable Variable;
        public override IDataVariable<List<float3>> m_variable => Variable;

        public Vector3ListReference(List<float3> value) : base(value)
        { }
    }
}
#endif