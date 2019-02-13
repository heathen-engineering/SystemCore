using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.UIX
{
    [ExecuteInEditMode]
    [AddComponentMenu("Heathen/Variables/Display Double Value")]
    public class DisplayDoubleValue : MonoBehaviour
    {
        public DoubleReference Value;
        public UnityEngine.UI.Text Text;        
        public StringReference FormatString = new StringReference("0.##");
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
                Text.text = Value.Value.ToString(FormatString);
            }
        }
    }
}
