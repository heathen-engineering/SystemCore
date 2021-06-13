using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    /// <summary>
    /// Practical example using the InstanceRenderer funcitonality
    /// </summary>
    public class ProjectileSpawner : MonoBehaviour
    {
        private MoveVectorJob projectileMoveJob;
        private JobHandle projectileMoveJobHandle;
        public NativeArray<Vector3> Vectors;
        public NativeArray<Vector3> Directions;
        public NativeArray<float> Speeds;

        /// <summary>
        /// Defines the shape of our projectile data
        /// </summary>
        [Serializable]
        public class ProjectileData : MatrixTransformData
        {
            //Custom data
            public float experation;
            public float damage;
            public float speed;
        }

        /// <summary>
        /// Wraps the generic InstanceRenderer for easier display in Unity Editor
        /// </summary>
        [Serializable]
        public class ProjectileInstanceRenderer : InstanceRenderer<ProjectileData> { }
        
        public float projectileDamage;
        public float projectileExperation;
        public float projectileSpeed;
        public LayerMask collisionLayers;
        public ProjectileInstanceRenderer Renderer = new ProjectileInstanceRenderer();

        private RaycastHit[] rayHitBuffer = new RaycastHit[1];
        private Collider[] pointTestBuffer = new Collider[1];

        public ProjectileData Spawn()
        {
            ProjectileData n = new ProjectileData()
            {
                position = Vector3.zero,
                rotation = Quaternion.identity,
                scale = Vector3.one,
                experation = projectileExperation,
                damage = projectileDamage,
                speed = projectileSpeed
            };

            Renderer.Spawn(n);

            return n;
        }

        public ProjectileData Spawn(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            ProjectileData n = new ProjectileData()
            {
                position = position,
                rotation = rotation,
                scale = scale,
                experation = projectileExperation,
                damage = projectileDamage,
                speed = projectileSpeed
            };

            Renderer.Spawn(n);

            return n;
        }

        public ProjectileData Spawn(Vector3 position, Quaternion rotation, Vector3 scale, float lifeTime, float damage, float speed)
        {
            ProjectileData n = new ProjectileData()
            {
                position = position,
                rotation = rotation,
                scale = scale,
                experation = lifeTime,
                damage = damage,
                speed = speed
            };

            Renderer.Spawn(n);

            return n;
        }

        /// <summary>
        /// Siulates the movement and collision of simple projectiles
        /// </summary>
        /// <param name="tick"></param>
        private void UpdateProjectiles(float tick)
        {
            projectileMoveJobHandle.Complete();

            for (int i = 0; i < Vectors.Length; i++)
            {
                var projectile = Renderer.instances[i];
                projectile.position = Vectors[i];
                projectile.experation -= tick;

                //If not dead yet test physics
                if (projectile.experation > 0)
                {
                    //test if we are inside something that we should have collided with
                    if (Physics.OverlapSphereNonAlloc(projectile.position, 0.01f, pointTestBuffer) > 0)
                    {
                        //A collision has occured so set the experation to a value less than 0
                        projectile.experation = -1;
                        var target = pointTestBuffer[0].GetComponent<IDamageHandler<DamageHandler.Report>>();
                        if (target != null)
                        {
                            target.ApplyDamage(new DamageHandler.Report() { damageValue = projectile.damage, worldPosition = projectile.position, direction = Directions[i] });
                        }
                    }
                }
            }

            //Remove all expired instances
            Renderer.instances.RemoveAll(p => p.experation <= 0);

            if (Vectors.IsCreated)
                Vectors.Dispose();
            if (Directions.IsCreated)
                Directions.Dispose();
            if (Speeds.IsCreated)
                Speeds.Dispose();

            //Build out the job data ECS would make this much faster
            var count = Renderer.instances.Count;
            Vectors = new NativeArray<Vector3>(count, Allocator.Persistent);
            Directions = new NativeArray<Vector3>(count, Allocator.Persistent);
            Speeds = new NativeArray<float>(count, Allocator.Persistent);

            for (int i = 0; i < Renderer.instances.Count; i++)
            {
                var projectile = Renderer.instances[i];
                Vectors[i] = projectile.position;
                Directions[i] = projectile.rotation * Vector3.forward;
                Speeds[i] = projectile.speed;
            }

            projectileMoveJob = new MoveVectorJob()
            {
                Vectors = Vectors,
                Directions = Directions,
                Speeds = Speeds,
                deltaTime = tick
            };

            //Kick the job off
            projectileMoveJobHandle = projectileMoveJob.Schedule(count, 64);
        }

        void FixedUpdate()
        {
            UpdateProjectiles(Time.fixedDeltaTime);
        }

        private void Update()
        {
            Renderer.Render();
        }

        private void OnDestroy()
        {
            projectileMoveJobHandle.Complete();
            if (Vectors.IsCreated)
                Vectors.Dispose();
            if (Directions.IsCreated)
                Directions.Dispose();
            if (Speeds.IsCreated)
                Speeds.Dispose();
        }
    }
}

