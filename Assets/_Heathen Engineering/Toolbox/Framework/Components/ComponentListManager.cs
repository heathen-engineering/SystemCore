using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [AddComponentMenu("Heathen/Generic/Component List Manager")]
    public class ComponentListManager : MonoBehaviour
    {
        public ComponentList List;
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

        public void AddComponenet(Component component)
        {
            List.AddComponent(component);
        }

        public void RemoveComponenet(Component component)
        {
            List.RemoveComponent(component);
        }

        public void Clear()
        {
            if (List != null)
                List.Values.Clear();
        }
    }
}
