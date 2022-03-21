#if HE_SYSCORE
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HeathenEngineering.Serializable
{
    [Serializable]
    public class KeyedDataLibrary
    {
        private List<KeyedObject> Values;

        [NonSerialized]
        private Dictionary<string, KeyedObject> Index;
        [NonSerialized]
        private bool isIndexed = false;

        public object this[string key]
        {
            get
            {
                return GetValue(key);
            }
            set
            {
                SetValue(key, value);
            }
        }
        
        public KeyedDataLibrary()
        {
            Values = new List<KeyedObject>();
            Index = new Dictionary<string, KeyedObject>();
            isIndexed = false;
        }

        public void BuildIndex()
        {
            if(!isIndexed)
            {
                if (Index == null)
                    Index = new Dictionary<string, KeyedObject>();
                else if (Index.Count > 0)
                    Index.Clear();

                foreach(var d in Values)
                {
                    Index.Add(d.Key, d);
                }
            }
        }

        public bool Contains(string key)
        {
            BuildIndex();
            return Index.ContainsKey(key);
        }
        
        public object GetValue(string key)
        {
            BuildIndex();
            if (Index.ContainsKey(key))
                return Index[key].Data;
            else
                return null;
        }

        public T GetValue<T>(string key)
        {
            BuildIndex();
            if (Index.ContainsKey(key))
                return (T)Index[key].Data;
            else
                return default(T);
        }

        public void SetValue(string key, object value)
        {
            BuildIndex();
            if (Index.ContainsKey(key))
                Index[key].Data = value;
            else
            {
                KeyedObject data = new KeyedObject() { Key = key, Data = value };
                Values.Add(data);
                Index.Add(key, data);
            }
        }

        public void Remove(string key)
        {
            BuildIndex();
            if(Index.ContainsKey(key))
            {
                Values.Remove(Index[key]);
                Index.Remove(key);
            }
        }

        public static byte[] Serialize(KeyedDataLibrary Library)
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

        public static KeyedDataLibrary Deserialize(byte[] Buffer)
        {
            KeyedDataLibrary Library = null;
            if (Buffer != null && Buffer.Length > 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream(Buffer);
                Library = bf.Deserialize(ms) as KeyedDataLibrary;
                ms.Dispose();
            }

            if(Library != null)
            {
                Library.isIndexed = false;
                Library.BuildIndex();
            }

            return Library;
        }
    }
    
}
#endif