using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.UIX
{
    [ExecuteInEditMode]
    [AddComponentMenu("Heathen/Variables/Text Color Setter Range")]
    public class TextColorSetterRange : MonoBehaviour
    {
        public FloatReference Value = new FloatReference(0.5f);
        public UnityEngine.UI.Text Text;        
        public FloatReference Minimal = new FloatReference(0);
        public ColorReference MinimalColor = new ColorReference(new Color(0,0,0,0));
        public FloatReference Maximum = new FloatReference(1);
        public ColorReference MaximumColor = new ColorReference(Color.white);
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

        public Color GetCurrentColor()
        {
            return Color.Lerp(MinimalColor, MaximumColor, Value);
        }

        [ContextMenu("Refresh")]
        public void Refresh()
        {
            if (Text != null)
            {
                Text.color = GetCurrentColor();
            }
        }
    }
}
