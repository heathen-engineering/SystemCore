using HeathenEngineering.Events;
using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.UIX
{
    [RequireComponent(typeof(UnityEngine.UI.Slider))]
    [AddComponentMenu("System Core/Tools/Slider Sync")]
    public class SliderSync : MonoBehaviour
    {
        public FloatVariable value;

        private UnityEngine.UI.Slider targetSlider;
        private bool interanlUpdate = false;

        private void Start()
        {
            Refresh();
        }

        private void OnEnable()
        {
            targetSlider = GetComponent<UnityEngine.UI.Slider>();

            targetSlider.onValueChanged.AddListener(HandleValueChanged);

            if (value != null)
                value.AddListener(HandleVariableChange);

            Refresh();
        }

        private void HandleValueChanged(float value)
        {
            if (interanlUpdate)
                return;

            interanlUpdate = true;
            if (this.value != null)
                this.value.Value = value;
            interanlUpdate = false;
        }

        private void OnDisable()
        {
            if (value != null)
                value.RemoveListener(HandleVariableChange);
        }

        private void HandleVariableChange(ChangeEventData<float> data)
        {
            if (interanlUpdate)
                return;

            interanlUpdate = true;
            targetSlider.value = data.newValue;
            interanlUpdate = false;
        }

        public void Refresh()
        {
            if (value != null)
            {
                interanlUpdate = true;
                targetSlider.value = value.Value;
                interanlUpdate = false;
            }
        }
    }
}
