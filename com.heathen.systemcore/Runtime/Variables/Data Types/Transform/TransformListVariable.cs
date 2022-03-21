#if HE_SYSCORE
using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Lists/Transform")]
    public class TransformListVariable : CollectionDataVariable<SerializableTransform>
    { }
}
#endif