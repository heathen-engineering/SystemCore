using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Serializable.Demo
{
    public class ExampleReferencingAVariable : MonoBehaviour
    {
        public BoolReference useAsAConstant;
        public BoolReference useAsAReference;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("The constant value is " + useAsAConstant.Value.ToString());
            Debug.Log("The constant value is " + useAsAReference.Value.ToString());
        }
    }
}
