using UnityEngine;
using HeathenEngineering.Scriptable;

namespace HeathenEngineering.Tools
{
    [RequireComponent(typeof(UnityEngine.UI.Dropdown))]
    [AddComponentMenu("System Core/Application/Language Dropdown")]
    public class LanguageDropdown : MonoBehaviour
    {
        [Tooltip("This field manager will be activated as the 'Active Manager' when this control awakes.")]
        public StringFieldManager fieldManager;
        private UnityEngine.UI.Dropdown dropdown;

        private void Awake()
        {
            dropdown = GetComponent<UnityEngine.UI.Dropdown>();
            if (dropdown != null)
            {
                dropdown.onValueChanged.AddListener(handleDropdownChange);
                RefreshListOptions();
            }
        }

        public void RefreshListOptions()
        {
            if(dropdown != null)
            {
                dropdown.options.Clear();
                if (fieldManager != null)
                {
                    fieldManager.Activate();
                    foreach (var set in fieldManager.availableSets)
                    {
                        dropdown.options.Add(new UnityEngine.UI.Dropdown.OptionData() { text = set.DisplayName, image = set.Icon });
                    }
                }
            }
        }

        private void handleDropdownChange(int arg0)
        {
            fieldManager.applyStringSet(fieldManager.availableSets[arg0].Data);
        }
    }
}
