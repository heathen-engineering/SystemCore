using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    /// <summary>
    /// Similar to MoveVectorJob but shares a single speed for all vectors
    /// Updates a set of vectors to move in coraponding directions by the provided speed
    /// </summary>
    /// <remarks>
    /// Vectors should be a list of the current positions and will be updated to represent the new positions
    /// Directions should be a 1 for 1 list of world space directions
    /// </remarks>
    public struct MoveVectorFixedSpeedJob : IJobParallelFor
    {
        public NativeArray<Vector3> Vectors;
        [ReadOnly]
        public NativeArray<Vector3> Directions;
        [ReadOnly]
        public float Speed;
        [ReadOnly]
        public float deltaTime;

        public void Execute(int index)
        {
            var pos = Vectors[index];
            var dir = Directions[index].normalized;
            Vectors[index] = pos + (dir * Speed * deltaTime);
        }
    }
}
