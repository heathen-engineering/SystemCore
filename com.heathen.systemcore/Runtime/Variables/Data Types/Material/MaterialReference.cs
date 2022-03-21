#if HE_SYSCORE
using System;
using UnityEngine;

namespace HeathenEngineering
{
    [Serializable]
    public class MaterialReference : VariableReference<Material>
    {
        public MaterialPointerVariable Variable;
        public override IDataVariable<Material> m_variable => Variable;

        public MaterialReference(Material value) : base(value)
        { }
    }
}
#endif