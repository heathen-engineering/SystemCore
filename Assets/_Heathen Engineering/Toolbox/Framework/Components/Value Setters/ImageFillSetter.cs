using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.UIX
{
    [ExecuteInEditMode]
    [AddComponentMenu("Heathen/Variables/Image Fill Setter")]
    public class ImageFillSetter : MonoBehaviour
    {
        public FloatReference Value;
        public UnityEngine.UI.Image Image;
        public BoolReference alwaysApply = new BoolReference(true);

        private void Update()
        {
            if (alwaysApply || !Application.isPlaying)
                Refresh();
        }

        [ContextMenu("Refresh")]
        public void Refresh()
        {
            if (Image != null)
            {
                Image.fillAmount = Value;
            }
        }
    }
}
