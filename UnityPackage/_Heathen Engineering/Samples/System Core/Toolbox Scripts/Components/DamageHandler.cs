using System;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Tools
{
    /// <summary>
    /// Basic float implamentation of the IDamageHandler interface
    /// </summary>
    public class DamageHandler : MonoBehaviour, IDamageHandler<DamageHandler.Report>
    {
        [Serializable]
        public class Report
        {
            //Amount of damage delt
            public float damageValue;
            //location assoceated with the damage dealt
            public Vector3 worldPosition;
            //direction the damage came from e.g. moving in this direction will move away from the source of the damage
            public Vector3 direction;
        }

        [Serializable]
        public class DamagedEvent : UnityEvent<Report>
        { }

        public DamagedEvent DamageRecieved;

        public void ApplyDamage(Report data)
        {
            DamageRecieved.Invoke(data);
        }
    }
}

