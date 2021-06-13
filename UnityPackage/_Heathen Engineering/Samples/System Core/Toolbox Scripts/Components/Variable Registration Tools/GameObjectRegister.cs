using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [AddComponentMenu("System Core/Tools/Game Object Register")]
    public class GameObjectRegister : MonoBehaviour
    {
        public GameObjectPointerVariable ReferenceVariable;

        private void Start()
        {
            if (ReferenceVariable != null)
                ReferenceVariable.Value = gameObject;
        }
        
        private void OnDestroy()
        {
            if (ReferenceVariable != null)
                ReferenceVariable.Value = null;
        }
    }
}
