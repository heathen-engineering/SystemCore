#if HE_SYSCORE
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace HeathenEngineering
{
    [Serializable]
    public class StringSet
    {
        public List<StringFieldValue> Values = new List<StringFieldValue>();

        public string GetValue(uint Id)
        {
            var t = Values.FirstOrDefault(p => p.Field.Id == Id);
            if (t != null)
            {
                return t.value;
            }
            else
                return string.Empty;
        }

        public static byte[] Serialize(StringSet Library)
        {
            byte[] Buffer = null;
            if (Library != null)
            {
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, Library);
                Buffer = ms.ToArray();
                ms.Dispose();
            }
            return Buffer;
        }

        public static StringSet Deserialize(byte[] Buffer)
        {
            StringSet appSet = null;
            if (Buffer != null && Buffer.Length > 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream(Buffer);
                appSet = bf.Deserialize(ms) as StringSet;
                ms.Dispose();
            }
            return appSet;
        }
    }
}
#endif