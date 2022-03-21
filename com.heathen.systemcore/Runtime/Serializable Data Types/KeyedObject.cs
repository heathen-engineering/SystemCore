#if HE_SYSCORE
using System;

namespace HeathenEngineering.Serializable
{
    [Serializable]
    public class KeyedObject
    {
        public KeyedObject() { }
        public string Key;
        public object Data;
    }
    
}
#endif