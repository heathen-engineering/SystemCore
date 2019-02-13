using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [AddComponentMenu("Heathen/Generic/Game Object List Manager")]
    public class ObjectListManager : MonoBehaviour
    {
        public ObjectList List;
        public bool ClearOnStart = false;
        public bool ClearOnDestroy = false;
        public bool ClearOnEnable = false;
        public bool ClearOnDisable = false;

        private void Start()
        {
            if (ClearOnStart && List != null)
                List.Values.Clear();
        }

        private void OnDestroy()
        {
            if (ClearOnDestroy && List != null)
                List.Values.Clear();
        }

        private void OnEnable()
        {
            if (ClearOnEnable && List != null)
                List.Values.Clear();
        }

        private void OnDisable()
        {
            if (ClearOnDisable && List != null)
                List.Values.Clear();
        }

        public void AddComponenet(GameObject go)
        {
            List.AddObject(go);
        }

        public void RemoveComponenet(GameObject go)
        {
            List.RemoveObject(go);
        }

        public void Clear()
        {
            if (List != null)
                List.Values.Clear();
        }
    }
}
