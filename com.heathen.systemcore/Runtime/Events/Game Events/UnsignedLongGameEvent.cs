#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/Unsigned Long")]
    public class UnsignedLongGameEvent : GameEvent<ulong>
    { }
}
#endif