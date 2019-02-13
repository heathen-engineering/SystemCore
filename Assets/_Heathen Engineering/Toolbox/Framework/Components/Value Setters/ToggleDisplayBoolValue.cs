using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.UIX
{
    [ExecuteInEditMode]
    [AddComponentMenu("Tools/UIX/Toggle Display Bool Value")]
    public class ToggleDisplayBoolValue : MonoBehaviour
    {
        public BoolReference Value = new BoolReference(false);
        public UnityEngine.UI.Toggle Toggle;
        public BoolReference alwaysApply = new BoolReference(false);

        private void OnEnable()
        {
            Refresh();
        }

        private void Update()
        {
            if (alwaysApply || !Application.isPlaying)
                Refresh();
        }

        [ContextMenu("Refresh")]
        public void Refresh()
        {
            if (Toggle != null)
            {
                Toggle.isOn = Value.Value;
            }
        }
    }
}
