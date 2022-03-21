#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Change Events/Bool")]
    public class BoolChangeEvent : ChangeEvent<bool>
    { }
}
#endif