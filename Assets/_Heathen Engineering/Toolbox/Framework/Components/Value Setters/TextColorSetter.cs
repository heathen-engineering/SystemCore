using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [ExecuteInEditMode]
    [AddComponentMenu("Heathen/Variables/Text Color Setter")]
    public class TextColorSetter : MonoBehaviour
    {
        public ColorReference Value = new ColorReference(new Color(50 / 255, 50 / 255, 50 / 255));
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
                    text.color = Value;
                }
            }
        }
    }
}
