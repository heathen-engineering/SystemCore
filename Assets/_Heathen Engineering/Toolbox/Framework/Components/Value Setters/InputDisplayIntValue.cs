using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.UIX
{
    [ExecuteInEditMode]
    [AddComponentMenu("Heathen/Variables/Input Display Int Value")]
    public class InputDisplayIntValue : MonoBehaviour
    {
        public IntReference Value = new IntReference(0);
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
                InputField.text = Value.Value.ToString();
            }
        }

        private void Update()
        {
            if (alwaysApply || !Application.isPlaying)
                Refresh();
        }

        public void InputFieldEndEdit(string value)
        {
            int buffer = 0;
            if (int.TryParse(value, out buffer))
                Value.Value = buffer;
        }
    }
}
