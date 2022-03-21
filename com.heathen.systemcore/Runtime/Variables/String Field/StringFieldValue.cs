#if HE_SYSCORE
using System;

namespace HeathenEngineering
{
    [Serializable]
    public class StringFieldValue
    {
        public StringField Field;
        public string value;
    }
}
#endif