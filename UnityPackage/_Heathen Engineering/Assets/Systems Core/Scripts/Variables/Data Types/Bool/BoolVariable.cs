using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Values/Bool")]
    public class BoolVariable : DataVariable<bool>
    {
        public void ToggleValue()
        {
            Value = !Value;
        }
    }
}
