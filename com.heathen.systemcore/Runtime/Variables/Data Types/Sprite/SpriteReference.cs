#if HE_SYSCORE
using System;
using UnityEngine;

namespace HeathenEngineering
{
    [Serializable]
    public class SpriteReference : VariableReference<Sprite>
    {
        public SpritePointerVariable Variable;
        public override IDataVariable<Sprite> m_variable => Variable;

        public SpriteReference(Sprite value) : base(value)
        { }
    }
}
#endif