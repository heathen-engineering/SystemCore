using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.UIX
{
    [ExecuteInEditMode]
    [AddComponentMenu("Heathen/Variables/Display Bool Value")]
    public class DisplayBoolValue : MonoBehaviour
    {
        public BoolReference Value = new BoolReference(false);
        public UnityEngine.UI.Text Text;        
        public BoolReference alwaysApply = new BoolReference(false);

        private void OnEnable()
        {
            Refresh();
        }

        private void Update()
        {
            if (alwaysApply || !Application.isPlaying)
            {
                Refresh();
            }
        }

        [ContextMenu("Refresh")]
        public void Refresh()
        {
            if (Text != null)
            {
                Text.text = Value.Value.ToString();
            }
        }
    }
}
