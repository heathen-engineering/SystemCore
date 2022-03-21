#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/Bool")]
    public class BoolGameEvent : GameEvent<bool>
    { }
}
#endif