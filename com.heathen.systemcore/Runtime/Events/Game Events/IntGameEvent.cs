#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/Int")]
    public class IntGameEvent : GameEvent<int>
    { }
}
#endif
