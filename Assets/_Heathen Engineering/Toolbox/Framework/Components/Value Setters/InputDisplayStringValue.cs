using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.UIX
{
    [ExecuteInEditMode]
    [AddComponentMenu("Heathen/Variables/Input Display String Value")]
    public class InputDisplayStringValue : MonoBehaviour
    {
        public StringReference Value;
        public UnityEngine.UI.InputField InputField;
        public BoolReference alwaysApply = new BoolReference(false);

        private void OnEnable()
        {
            Refresh();
        }

        [ContextMenu("Refresh")]
        public void Refresh()
        {
            if (InputField != null)
            {
                InputField.text = Value;
            }
        }

        private void Update()
        {
            if (alwaysApply || !Application.isPlaying)
                Refresh();
        }

        public void InputFieldEndEdit(string value)
        {
                Value.Value = value;
        }
    }
}
