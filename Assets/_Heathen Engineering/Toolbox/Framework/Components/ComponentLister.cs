using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [AddComponentMenu("Heathen/Generic/Component Lister")]
    public class ComponentLister : MonoBehaviour
    {
        public ComponentList TargetList;
        public Component SubjectComponent;

        private void OnEnable()
        {
            if (TargetList != null && SubjectComponent != null)
                TargetList.AddComponent(SubjectComponent);
        }

        private void OnDisable()
        {
            if (TargetList != null && SubjectComponent != null)
                TargetList.RemoveComponent(SubjectComponent);
        }
    }
    
}
