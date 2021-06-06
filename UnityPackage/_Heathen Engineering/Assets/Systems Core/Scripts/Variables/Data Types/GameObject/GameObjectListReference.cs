using System;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class GameObjectListReference : VariableReference<List<GameObject>>
    {
        public GameObjectPointerListVariable Variable;
        public override IDataVariable<List<GameObject>> m_variable => Variable;

        public GameObjectListReference(List<GameObject> value) : base(value)
        { }
    }
}
