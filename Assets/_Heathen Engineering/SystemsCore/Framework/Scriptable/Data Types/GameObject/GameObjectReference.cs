using System;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class GameObjectReference : VariableReference<GameObject>
    {
        public GameObjectPointerVariable Variable;

        public override IDataVariable<GameObject> m_variable => Variable;

        public GameObjectReference(GameObject value) : base(value)
        { }
    }
}
