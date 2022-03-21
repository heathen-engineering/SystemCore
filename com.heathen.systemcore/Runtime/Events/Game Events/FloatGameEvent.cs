#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/Float")]
    public class FloatGameEvent : GameEvent<float>
    { }
}
#endif