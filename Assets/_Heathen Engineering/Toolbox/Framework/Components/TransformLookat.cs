using HeathenEngineering.Scriptable;

namespace HeathenEngineering.Tools
{
    public class TransformLookat : HeathenBehaviour
    {
        public Vector3Reference worldPosition;
        public Vector3Reference worldUp;

        private void Update()
        {
            selfTransform.LookAt(worldPosition.Value, worldUp.Value);
        }
    }
}

