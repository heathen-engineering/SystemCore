using HeathenEngineering.Events;
using HeathenEngineering.Scriptable;
using System;
using UnityEngine;

namespace HeathenEngineering.UIX
{
    [RequireComponent(typeof(UnityEngine.UI.Toggle))]
    [AddComponentMenu("System Core/Tools/Toggle Sync")]
    public class ToggleSync : MonoBehaviour
    {
        public BoolVariable isOn;

        private UnityEngine.UI.Toggle targetToggle;
        private bool interanlUpdate = false;

        private void Start()
        {
            Refresh();
        }

        private void OnEnable()
        {
            targetToggle = GetComponent<UnityEngine.UI.Toggle>();

            targetToggle.onValueChanged.AddListener(HandleToggleValueChanged);

            if (isOn != null)
                isOn.AddListener(HandleIsOnChange);

            Refresh();
        }

        private void HandleToggleValueChanged(bool value)
        {
            if (interanlUpdate)
                return;

            interanlUpdate = true;
            if (isOn != null)
                isOn.Value = value;
            interanlUpdate = false;
        }

        private void OnDisable()
        {
            if (isOn != null)
                isOn.RemoveListener(HandleIsOnChange);
        }

        private void HandleIsOnChange(ChangeEventData<bool> data)
        {
            if (interanlUpdate)
                return;

            interanlUpdate = true;
            targetToggle.isOn = data.newValue;
            interanlUpdate = false;
        }

        public void Refresh()
        {
            if (isOn != null)
            {
                interanlUpdate = true;
                targetToggle.isOn = isOn.Value;
                interanlUpdate = false;
            }
        }
    }
}
