using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;

namespace HeathenEngineering.Tools
{
    /// <summary>
    /// Moves each transform in the corasponding relative direction at the corasponding speed
    /// </summary>
    /// <remarks>
    /// Directions should contain a local space direction vector for each transform e.g. 0,0,1 is the same as the transform.forward would be in mono behaviours
    /// Speeds should contain a speed expressed as units per second for each transform
    /// </remarks>
    public struct LocalDirectionMoveJob : IJobParallelForTransform
    {
        [ReadOnly]
        public NativeArray<Vector3> Directions;
        [ReadOnly]
        public NativeArray<float> Speeds;
        [ReadOnly]
        public float deltaTime;

        public void Execute(int index, TransformAccess transform)
        {
            var pos = transform.position;
            pos = Speeds[index] * deltaTime * (transform.rotation * Directions[index]);
            transform.position = transform.position + pos;
        }
    }
}
