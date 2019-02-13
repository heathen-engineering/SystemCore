using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.UIX
{
    [ExecuteInEditMode]
    [AddComponentMenu("Heathen/Variables/Image Fill Setter Curved")]
    public class ImageFillSetterCurved : MonoBehaviour
    {
        public FloatReference Value;
        public UnityEngine.UI.Image Image;        
        [Tooltip("Values at or below this amount will result in zero fill")]
        public FloatReference Minimal;
        [Tooltip("Values at or above this amount will result in complete fill")]
        public FloatReference Maximum;
        [Tooltip("Curve to evaluate in order to look up a final value to send as the fill.\n" +
                 "fill=0 is when Variable == Min\n" +
                 "fill=1 is when Variable == Max")]
        public AnimationCurveReference Curve;
        public BoolReference alwaysApply = new BoolReference(false);

        private void Update()
        {
            if (alwaysApply || !Application.isPlaying)
                Refresh();
        }

        [ContextMenu("Refresh")]
        public void Refresh()
        {
            float t = Mathf.InverseLerp(Minimal.Value, Maximum.Value, Value.Value);
            float value = Curve.Evaluate(Mathf.Clamp01(t));
            Image.fillAmount = value;
        }
    }
}
