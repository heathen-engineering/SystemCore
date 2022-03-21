#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering
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
#endif