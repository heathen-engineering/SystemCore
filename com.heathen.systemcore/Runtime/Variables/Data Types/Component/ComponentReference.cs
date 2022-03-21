#if HE_SYSCORE
using System;
using UnityEngine;

namespace HeathenEngineering
{
    [Serializable]
    public class ComponentReference : VariableReference<Component>
    {
        public ComponentPointerVariable Variable;
        public override IDataVariable<Component> m_variable => Variable;

        public ComponentReference(Component value) : base(value)
        { }
    }
}
#endif