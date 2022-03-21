#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Change Events/Unsigned Int")]
    public class UnsignedIntChangeEvent : ChangeEvent<uint>
    { }
}
#endif