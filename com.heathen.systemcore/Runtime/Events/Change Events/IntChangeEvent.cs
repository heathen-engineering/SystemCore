#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Change Events/Int")]
    public class IntChangeEvent : ChangeEvent<int>
    { }
}
#endif