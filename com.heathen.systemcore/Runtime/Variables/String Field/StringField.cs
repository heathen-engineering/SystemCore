#if HE_SYSCORE
using HeathenEngineering.Events;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Application/String Field")]
    public class StringField : ScriptableObject
    {
        public uint Id;
        public string defaultValue;
        [HideInInspector]
        public string activeValue;
        
        /// <summary>
        /// Insure that if the active value is null, empty or default that we use the defaultValue of this field
        /// </summary>
        public string Value
        {
            get
            {
                return string.IsNullOrEmpty(activeValue) ? defaultValue : activeValue;
            }
            set
            {
                if (activeValue != value)
                {
                    activeValue = value;
                    ValueChanged.Invoke(activeValue);
                }
            }
        }

        /// <summary>
        /// Apply defaults and trigger value changes as required
        /// </summary>
        public void ApplyDefault()
        {
            if (activeValue != defaultValue)
            {
                activeValue = defaultValue;
                ValueChanged.Invoke(activeValue);
            }
        }

        /// <summary>
        /// Used internally by behaviours to update when this field value changes
        /// </summary>
        [HideInInspector]
        public UnityStringEvent ValueChanged;
    }
}
#endif