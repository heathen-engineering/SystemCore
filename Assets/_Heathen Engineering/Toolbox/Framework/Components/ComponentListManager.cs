using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [AddComponentMenu("System Core/Generic/Component List Manager")]
    public class ComponentListManager : MonoBehaviour
    {
        public ComponentPointerListVariable List;
        public bool ClearOnStart = false;
        public bool ClearOnDestroy = false;
        public bool ClearOnEnable = false;
        public bool ClearOnDisable = false;

        private void Start()
        {
            if (ClearOnStart && List != null)
                List.Clear();
        }

        private void OnDestroy()
        {
            if (ClearOnDestroy && List != null)
                List.Clear();
        }

        private void OnEnable()
        {
            if (ClearOnEnable && List != null)
                List.Clear();
        }

        private void OnDisable()
        {
            if (ClearOnDisable && List != null)
                List.Clear();
        }

        public void AddComponenet(Component component)
        {
            List.Add(component);
        }

        public void RemoveComponenet(Component component)
        {
            List.Remove(component);
        }

        public void Clear()
        {
            if (List != null)
                List.Clear();
        }
    }
}
