using System;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class CameraListReference : VariableReference<List<Camera>>
    {
        public CameraPointerListVariable Variable;
        public override IDataVariable<List<Camera>> m_variable => Variable;

        public CameraListReference(List<Camera> value) : base(value)
        { }
    }
}
