#if HE_SYSCORE
using System;
using UnityEngine;

namespace HeathenEngineering
{
    [Serializable]
    public class TextureReference : VariableReference<Texture>
    {
        public TexturePointerVariable Variable;
        public override IDataVariable<Texture> m_variable => Variable;

        public TextureReference(Texture value) : base(value)
        { }
    }
}
#endif