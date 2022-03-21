#if HE_SYSCORE
using System;

namespace HeathenEngineering
{
    [Serializable]
    public class KeyedVariable
    {
        public string Key;
        public DataVariable Variable;
        public DataVariable Default;
    }
}
#endif