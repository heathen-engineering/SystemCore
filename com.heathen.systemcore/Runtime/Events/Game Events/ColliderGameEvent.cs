#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/Collider")]
    public class ColliderGameEvent : GameEvent<Collider>
    { }
}
#endif