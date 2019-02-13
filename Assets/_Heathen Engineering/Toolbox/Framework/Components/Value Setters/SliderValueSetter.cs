using HeathenEngineering.Scriptable;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HeathenEngineering.UIX
{
    [ExecuteInEditMode]
    [AddComponentMenu("Heathen/Variables/Slider Value Setter")]
    public class SliderValueSetter : MonoBehaviour
    {
        public FloatReference Value = new FloatReference(0);
        public UnityEngine.UI.Slider Slider;
        public BoolReference alwaysApply = new BoolReference(false);
        public BoolReference IgnoreUpdateIfSelected = new BoolReference(false);

        private void OnEnable()
        {
            Refresh();
        }

        private void Update()
        {
            if (alwaysApply || !Application.isPlaying)
            {
                if (!IgnoreUpdateIfSelected || EventSystem.current.currentSelectedGameObject != Slider.gameObject)
                    Refresh();
            }
        }

        [ContextMenu("Refresh")]
        public void Refresh()
        {
            if (Slider != null)
            {
                Slider.value = Value;
            }
        }
    }
}
