using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [AddComponentMenu("Tools/Sensors/Proximity Sensor")]
    public class ProximitySensor : ValueSensor<float>
    {
        [Tooltip("The current subject for which to test range against")]
        public TransformReference Subject;
        [Tooltip("At ranges beyond this value == 0")]
        public FloatReference MaximumRange;
        [Tooltip("At ranges nearer this value == 1")]
        public FloatReference MinimalRange;
        [Tooltip("The last calculated value")]
        public FloatReference referenceValue = new FloatReference(0);
        public override float Value
        {
            get
            {
                return referenceValue;
            }
        }

        [ContextMenu("Refresh")]
        public override void Refresh()
        {
            if (Subject.Value == null)
                referenceValue.Value = 0;
            else
                referenceValue.Value = Mathf.Clamp01(Mathf.InverseLerp(MaximumRange, MinimalRange, Vector3.Distance(Subject.Value.position, selfTransform.position)));
        }
    }
}
