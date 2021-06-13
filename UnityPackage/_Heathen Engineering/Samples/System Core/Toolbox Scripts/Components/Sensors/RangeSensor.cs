using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [AddComponentMenu("Tools/Sensors/Range Sensor")]
    public class RangeSensor : ValueSensor<float>
    {
        [Tooltip("The current subject for which to test range against")]
        public TransformReference Subject;
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
                referenceValue.Value = -1;
            else
                referenceValue.Value = Vector3.Distance(Subject.Value.position, selfTransform.position);
        }
    }
}
