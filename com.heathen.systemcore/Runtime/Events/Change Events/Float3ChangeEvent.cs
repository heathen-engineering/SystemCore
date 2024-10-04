#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Change Events/Float 3")]
    public class Float3ChangeEvent : ChangeEvent<float3>
    { }
}
#endif