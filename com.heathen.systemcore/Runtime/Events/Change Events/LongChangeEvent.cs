#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Change Events/Long")]
    public class LongChangeEvent : ChangeEvent<long>
    { }
}
#endif