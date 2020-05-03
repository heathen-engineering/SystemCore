using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class KeyedVariable
    {
        public string Key;
        public IDataVariable Variable;
        public IDataVariable Default;
    }
}
