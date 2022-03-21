#if HE_SYSCORE
using System;

namespace HeathenEngineering
{
    [Serializable]
    public class MultilineStringReference : StringReference
    {
        public MultilineStringReference(string value) : base(value)
        {
        }
        
    }
}
#endif