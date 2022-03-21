#if HE_SYSCORE
using System;

namespace HeathenEngineering
{
    [Serializable]
    public class ImageFillMethodReference : VariableReference<UnityEngine.UI.Image.FillMethod>
    {
        public ImageFillMethodPointerVariable Variable;
        public override IDataVariable<UnityEngine.UI.Image.FillMethod> m_variable => Variable;

        public ImageFillMethodReference(UnityEngine.UI.Image.FillMethod value) : base(value)
        { }
    }
}
#endif