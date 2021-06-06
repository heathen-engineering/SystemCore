using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [AddComponentMenu("System Core/Tools/Component List Register")]
    public class ComponentListRegister : MonoBehaviour
    {
        public ComponentPointerListVariable TargetList;
        public Component SubjectComponent;

        private void OnEnable()
        {
            if (TargetList != null && SubjectComponent != null)
                TargetList.Add(SubjectComponent);
        }

        private void OnDisable()
        {
            if (TargetList != null && SubjectComponent != null)
                TargetList.Remove(SubjectComponent);
        }
    }
    
}
