using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class ImageTypeReference : VariableReference<UnityEngine.UI.Image.Type>
    {
        public ImageTypePointerVariable Variable;
        public override IDataVariable<UnityEngine.UI.Image.Type> m_variable => Variable;

        public ImageTypeReference(UnityEngine.UI.Image.Type value) : base(value)
        { }
    }
}
