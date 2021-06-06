using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;

namespace HeathenEngineering.Tools
{
    /// <summary>
    /// Rotates each transform toward the corasponding direction by the corasponding speed
    /// </summary>
    /// <remarks>
    /// Directions should contain a world space direction vector for each transform e.g. 0,0,1 is looking down the global z axis
    /// Speeds should contain a speed expressed as units per second for each transform
    /// </remarks>
    public struct LookAtDirectionJob : IJobParallelForTransform
    {
        [ReadOnly]
        public NativeArray<Vector3> Directions;
        [ReadOnly]
        public NativeArray<float> Speeds;
        [ReadOnly]
        public float deltaTime;

        public void Execute(int index, TransformAccess transform)
        {
            var targetRot = Quaternion.LookRotation(Directions[index]);
            var myRot = transform.rotation;
            var slerpTime = deltaTime * Speeds[index];
            transform.rotation = Quaternion.Slerp(myRot, targetRot, slerpTime);
        }
    }
}
