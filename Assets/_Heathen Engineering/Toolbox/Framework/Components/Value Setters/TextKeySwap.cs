using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.UIX
{
    [ExecuteInEditMode]
    [AddComponentMenu("Heathen/Variables/Text Key Swap")]
    public class TextKeySwap : MonoBehaviour
    {
        public StringReference StringSource = new StringReference("");
        public UnityEngine.UI.Text DisplayText;
        public KeyedStringListVariable KeyLibrary;
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
            if (DisplayText != null && KeyLibrary != null)
            {
                DisplayText.text = KeyLibrary.SwapKeys(StringSource);
            }
        }
    }
}
