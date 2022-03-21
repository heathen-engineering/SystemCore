#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/Unsigned Int")]
    public class UnsignedIntGameEvent : GameEvent<uint>
    { }
}
#endif