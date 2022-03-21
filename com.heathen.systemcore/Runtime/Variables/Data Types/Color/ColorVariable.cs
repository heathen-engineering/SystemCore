#if HE_SYSCORE
using HeathenEngineering.Events;
using HeathenEngineering.Serializable;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Values/Color")]
    public class ColorVariable : DataVariable<float4>
    { }
}
#endif