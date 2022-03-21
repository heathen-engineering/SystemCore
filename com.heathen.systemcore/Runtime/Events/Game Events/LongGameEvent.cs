#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/Long")]
    public class LongGameEvent : GameEvent<long>
    { }
}
#endif