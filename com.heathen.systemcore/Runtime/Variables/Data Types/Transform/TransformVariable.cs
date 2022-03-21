#if HE_SYSCORE
using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Values/Transform")]
    public class TransformVariable : DataVariable<SerializableTransform>
    { }
}
#endif