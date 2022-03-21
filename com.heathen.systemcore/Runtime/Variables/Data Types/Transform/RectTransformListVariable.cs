#if HE_SYSCORE
using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Lists/RectTransform")]
    public class RectTransformListVariable : CollectionDataVariable<SerializableRectTransform>
    { }
}
#endif