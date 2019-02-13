using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.UIX
{
    [ExecuteInEditMode]
    [AddComponentMenu("Heathen/Variables/Input Display Double Value")]
    public class InputDisplayDoubleValue : MonoBehaviour
    {
        public DoubleReference Value = new DoubleReference(0);
        public UnityEngine.UI.InputField InputField;
        public BoolReference alwaysApply = new BoolReference(true);

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
            double buffer = 0;
            if (double.TryParse(value, out buffer))
                Value.Value = buffer;
        }
    }
}
