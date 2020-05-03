using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class FloatReference : VariableReference<float>
    {
        public FloatVariable Variable;

        public override IDataVariable<float> m_variable => Variable;

        public FloatReference(float value) : base(value)
        { }
    }
}
