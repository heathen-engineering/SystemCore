using UnityEngine;
using System.Collections.Generic;

namespace HeathenEngineering.Tools
{
    [AddComponentMenu("Tools/Sensors/Sensor Manager")]
    public class SensorController : MonoBehaviour
    {
        public List<ValueSensor> Sensors = new List<ValueSensor>();

        private void OnEnable()
        {
            foreach (ValueSensor s in GetComponentsInChildren<ValueSensor>())
            {
                if (!Sensors.Contains(s))
                    Sensors.Add(s);
            }
        }

        private void Update()
        {
            foreach(var s in Sensors)
            {
                if (s != null)
                    s.Refresh();
            }
        }
    }
}
