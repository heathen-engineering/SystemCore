using UnityEngine;
using HeathenEngineering.Scriptable;

namespace HeathenEngineering.Tools
{
    [AddComponentMenu("System Core/Application/Manager Activator")]
    public class ActivateStringFieldManager : MonoBehaviour
    {
        [Tooltip("This field manager will be activated as the 'Active Manager' when this control awakes.")]
        public StringFieldManager fieldManager;
        private void Awake()
        {
            if (fieldManager != null)
                fieldManager.Activate();
        }

        public void Activate()
        {
            if (fieldManager != null)
                fieldManager.Activate();
        }
    }
}
