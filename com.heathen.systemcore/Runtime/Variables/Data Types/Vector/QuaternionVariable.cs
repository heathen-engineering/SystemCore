#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Values/Quaternion")]
    public class QuaternionVariable : DataVariable<quaternion>
    { }
}
#endif