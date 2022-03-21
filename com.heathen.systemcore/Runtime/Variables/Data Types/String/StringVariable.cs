#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Values/String")]
    public class StringVariable : DataVariable<string>
    { }
}
#endif