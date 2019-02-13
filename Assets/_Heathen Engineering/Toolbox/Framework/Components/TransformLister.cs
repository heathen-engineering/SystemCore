using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [AddComponentMenu("Heathen/Generic/Transform Lister")]
    public class TransformLister : HeathenBehaviour
    {
        public TransformList TargetList;

        private void OnEnable()
        {
            if (TargetList != null)
                TargetList.AddObject(selfTransform);
        }

        private void OnDisable()
        {
            if (TargetList != null)
                TargetList.RemoveObject(selfTransform);
        }
    }
}
