using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;

namespace HeathenEngineering.Tools
{
    /// <summary>
    /// Moves each transform in the corasponding direction at the corasponding speed
    /// </summary>
    /// <remarks>
    /// Directions should contain a world space direction vector for each transform
    /// Speeds should contain a speed expressed as units per second for each transform
    /// </remarks>
    public struct WorldDirectionMoveJob : IJobParallelForTransform
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
            pos = Speeds[index] * deltaTime * Directions[index];
            transform.position = transform.position + pos;
        }
    }
}
