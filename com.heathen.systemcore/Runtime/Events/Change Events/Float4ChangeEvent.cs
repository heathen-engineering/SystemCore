#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Change Events/Float 4")]
    public class Float4ChangeEvent : ChangeEvent<float4>
    { }
}
#endif