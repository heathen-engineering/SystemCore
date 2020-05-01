using UnityEngine;
using HeathenEngineering.Tools;

namespace HeathenEngineering.Tools.Demo
{
    public class SpawnProjectiles : MonoBehaviour
    {
        public ProjectileSpawner spawner;
        public Vector3[] spawnPoints;
        public float spawnPointRotationSpeed = 540;
        public UnityEngine.UI.Text countLabel;
        public UnityEngine.UI.Toggle autoSpawn;
        public UnityEngine.UI.Slider speedSlider;

        private Quaternion rot;
        private Vector3 bulletScale = new Vector3(0.1f, 0.1f, 0.1f);
        private float spawnTime = 0;

        Quaternion right;
        Quaternion left;
        Quaternion back;

        private void Start()
        {
            rot = Quaternion.identity;
            right = Quaternion.Euler(0, 90, 0);
            left = Quaternion.Euler(0, 270, 0);
            back = Quaternion.Euler(0, 180, 0);
        }

        private void Update()
        {
            countLabel.text = spawner.Renderer.instances.Count.ToString();
            rot *= Quaternion.Euler(0, spawnPointRotationSpeed * Time.deltaTime, 0);

            //Unity seems to muck up the quaternion when rotating like this so hackish solution... just normalize the quaternion to prevent invalid quat exceptions
            float f = 1f / Mathf.Sqrt(rot.x * rot.x + rot.y * rot.y + rot.z * rot.z + rot.w * rot.w);
            rot = new Quaternion(rot.x * f, rot.y * f, rot.z * f, rot.w * f);

            if (autoSpawn.isOn)
            {
                if (spawnTime + speedSlider.value < Time.time)
                {
                    Spawn();
                    spawnTime = Time.time;
                }
            }
        }

        public void Spawn()
        {
            foreach (var v in spawnPoints)
            {
                spawner.Spawn(v, rot, bulletScale);
                spawner.Spawn(v, rot * right, bulletScale);
                spawner.Spawn(v, rot * left, bulletScale);
                spawner.Spawn(v, rot * back, bulletScale);
            }
        }
    }
}
