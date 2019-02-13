using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.UIX
{
    [ExecuteInEditMode]
    [AddComponentMenu("Heathen/Variables/Image Fill Setter Ranged")]
    public class ImageFillSetterRanged : MonoBehaviour
    {
        public FloatReference Value = new FloatReference(0.5f);
        public UnityEngine.UI.Image Image;        
        [Tooltip("Values at or below this amount will result in zero fill")]
        public FloatReference Minimal = new FloatReference(0);
        [Tooltip("Values at or above this amount will result in complete fill")]
        public FloatReference Maximum = new FloatReference(1);
        public BoolReference alwaysApply = new BoolReference(false);

        private void Update()
        {
            if (alwaysApply || !Application.isPlaying)
                Refresh();
        }

        [ContextMenu("Refresh")]
        public void Refresh()
        {
            if(Image != null)
            {
                if (Value <= Minimal)
                    Image.fillAmount = 0;
                else if (Value >= Maximum)
                    Image.fillAmount = 1;
                else
                {
                    if (Maximum > Minimal)
                        Image.fillAmount = (Value - Minimal) / (Maximum - Minimal);
                }
            }
        }
    }
}
