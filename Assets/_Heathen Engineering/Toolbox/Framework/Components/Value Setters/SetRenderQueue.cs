using UnityEngine;
using System.Collections.Generic;
using HeathenEngineering.Scriptable;

namespace HeathenEngineering.UIX
{
    [AddComponentMenu("Heathen/General/Set Render Queue")]
    public class SetRenderQueue : MonoBehaviour
    {
        [Tooltip("All renderers at or below this object will have there materials set to this queue level")]
        public IntReference targetQueue = new IntReference(3020);

        public List<Renderer> managedRenderers
        {
            get;
            private set;
        }

        public List<Material> managedMaterials
        {
            get;
            private set;
        }

        private int prev_targetQueue = 3020;

        // Use this for initialization
        void Start()
        {
            prev_targetQueue = targetQueue;
            UpdateManagedRenderersList();
        }

        // Update is called once per frame
        void Update()
        {
            if(prev_targetQueue != targetQueue)
            {
                prev_targetQueue = targetQueue;
                UpdateManagedMaterials();
            }
        }

        public void UpdateManagedRenderersList()
        {
            if (managedRenderers == null)
                managedRenderers = new List<Renderer>();

            if (managedMaterials == null)
                managedMaterials = new List<Material>();

            managedRenderers.Clear();

            foreach (Renderer rend in gameObject.GetComponentsInChildren<Renderer>())
            {
                managedRenderers.Add(rend);
                foreach (Material mat in rend.materials)
                {
                    if (!managedMaterials.Contains(mat))
                        managedMaterials.Add(mat);

                    mat.renderQueue = targetQueue;
                }
            }
        }

        public void UpdateManagedMaterials()
        {
            foreach(Material mat in managedMaterials)
            {
                mat.renderQueue = targetQueue;
            }
        }

        void OnDestroy()
        {
            while (managedMaterials.Count != 0)
            {
                Material mat = managedMaterials[0];
                managedMaterials.Remove(mat);
                if (mat != null)
                {
                    Destroy(mat);
                    mat = null;
                }
            }
        }
    }
}