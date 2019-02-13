using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HeathenEngineering.Tools
{

    /// <summary>
    /// Renders multiple copies of the same mesh and material combination. Ideal replacement for classic 'object pools'
    /// </summary>
    [Serializable]
    public class InstanceRenderer<T> : IInstanceRenderer<T> where T : IMatrixTransformData, new()
    {
        public Mesh mesh;
        public Material material;
        public List<T> instances = new List<T>();

        public T Spawn()
        {
            T n = new T();

            instances.Add(n);

            return n;
        }
        
        public void Spawn(T data)
        {
            if (!instances.Contains(data))
                instances.Add(data);
        }

        public void Remove(T data)
        {
            instances.Remove(data);
        }

        public void Render()
        {
            if (instances.Count <= 0)
                return;


            //bufferedData.Clear();

            if (instances.Count < 1023) //Only 1 batch needed
            {
                Matrix4x4[] tBuffer = instances.Select(instances => instances.TRS).ToArray();
                Graphics.DrawMeshInstanced(mesh, 0, material, tBuffer, tBuffer.Length);
            }
            else
            {
                int count = instances.Count;
                for (int i = 0; i < count; i += 1023) //Break into batches
                {
                    if (i + 1023 < count)
                    {
                        Matrix4x4[] tBuffer = new Matrix4x4[1023];
                        for (int ii = 0; ii < 1023; ii++)
                        {
                            tBuffer[ii] = instances[i + ii].TRS;
                        }
                        Graphics.DrawMeshInstanced(mesh, 0, material, tBuffer, tBuffer.Length);
                    }
                    else
                    {
                        //last batch
                        Matrix4x4[] tBuffer = new Matrix4x4[count - i];
                        for (int ii = 0; ii < count - i; ii++)
                        {
                            tBuffer[ii] = instances[i + ii].TRS;
                        }
                        Graphics.DrawMeshInstanced(mesh, 0, material, tBuffer, tBuffer.Length);
                    }
                }

            }
        }
    }
}

