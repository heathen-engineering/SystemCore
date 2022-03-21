#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Change Events/String")]
    public class StringChangeEvent : ChangeEvent<string>
    { }
}
#endif