using System;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class ComponentListReference : VariableReference<List<Component>>
    {
        public ComponentPointerListVariable Variable;
        public override IDataVariable<List<Component>> m_variable => Variable;

        public ComponentListReference(List<Component> value) : base(value)
        { }
    }
}
