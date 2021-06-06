using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [AddComponentMenu("System Core/Tools/Transform List Register")]
    public class TransformListRegister : HeathenBehaviour
    {
        public TransformListVariable TargetList;

        private void OnEnable()
        {
            if (TargetList != null)
                TargetList.Add(selfTransform);
        }

        private void OnDisable()
        {
            if (TargetList != null)
                TargetList.Remove(selfTransform);
        }
    }
}
