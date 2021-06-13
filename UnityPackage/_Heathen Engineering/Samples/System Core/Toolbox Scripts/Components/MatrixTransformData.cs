using System;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [Serializable]
    public class MatrixTransformData : IMatrixTransformData
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
        public Matrix4x4 TRS
        {
            get { return Matrix4x4.TRS(position, rotation, scale); }
        }
    }
}

