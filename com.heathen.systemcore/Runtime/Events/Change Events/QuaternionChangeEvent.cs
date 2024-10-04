#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Change Events/Quaternion")]
    public class QuaternionChangeEvent : ChangeEvent<quaternion>
    { }
}
#endif