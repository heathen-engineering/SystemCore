#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Pointers/Lists/Camera")]
    public class CameraPointerListVariable : CollectionDataVariable<Camera>
    { }
}
#endif