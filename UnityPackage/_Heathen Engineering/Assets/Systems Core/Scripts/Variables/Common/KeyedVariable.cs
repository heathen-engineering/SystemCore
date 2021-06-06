using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class KeyedVariable
    {
        public string Key;
        public DataVariable Variable;
        public DataVariable Default;
    }
}
