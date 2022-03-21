#if HE_SYSCORE
using System;

namespace HeathenEngineering
{
    [Serializable]
    public class KeyedReference
    {
        public string Key;
        public StringReference Value;
    }
}
#endif