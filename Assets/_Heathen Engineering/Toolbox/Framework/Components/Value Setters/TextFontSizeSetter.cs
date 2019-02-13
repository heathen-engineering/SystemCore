using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [ExecuteInEditMode]
    [AddComponentMenu("Heathen/Variables/Text Font Size Setter")]
    public class TextFontSizeSetter : MonoBehaviour
    {
        public IntReference Value = new IntReference(14);
        public List<UnityEngine.UI.Text> Texts = new List<UnityEngine.UI.Text>();
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
            if (Texts == null)
                return;

            foreach (var text in Texts)
            {
                if (text != null)
                {
                    text.fontSize = Value;
                }
            }
        }
    }
}
