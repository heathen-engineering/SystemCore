#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Change Events/Float 2")]
    public class Float2ChangeEvent : ChangeEvent<float2>
    { }
}
#endif