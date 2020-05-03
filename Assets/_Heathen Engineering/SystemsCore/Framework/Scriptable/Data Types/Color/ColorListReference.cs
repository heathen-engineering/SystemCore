using HeathenEngineering.Serializable;
using System;
using System.Collections.Generic;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class ColorListReference : VariableReference<List<SerializableColor>>
    {
        public ColorListVariable Variable;
        public override IDataVariable<List<SerializableColor>> m_variable => Variable;

        public ColorListReference(List<SerializableColor> value) : base(value)
        { }
    }
}
