using DOTS.Components;
using DOTS.Physics;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Systems;
using UnityEngine;
using RaycastHit = Unity.Physics.RaycastHit;

namespace DOT.Systems
{
    [UpdateBefore(typeof(PhysicsSystemGroup))]
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    public partial class PlayerInputSystem : SystemBase
    {
        private Camera _mainCamera;
        private PhysicsWorldSingleton _physicsWorld;
        
        protected override void OnUpdate()
        {
            if (Input.GetMouseButtonUp(0))
            {
                SelectDestination();
            }
        }

        private void SelectDestination()
        {
            _mainCamera ??= Camera.main;
            
            if (_mainCamera == null)
                return;
            
            _physicsWorld = SystemAPI.GetSingleton<PhysicsWorldSingleton>();
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Raycast(ray.origin, ray.GetPoint(100f), out var hit))
            {
                var hitEntity = _physicsWorld.Bodies[hit.RigidBodyIndex].Entity;

                foreach (var destination in SystemAPI.Query<RefRW<Destination>>())
                {
                    destination.ValueRW.IsValid = true;
                    destination.ValueRW.Position = hit.Position;
                }
            }
        }

        private bool Raycast(float3 start, float3 end, out RaycastHit hit)
        {
            var raycastInput = new RaycastInput
            {
                Start = start,
                End = end,
                Filter = new CollisionFilter
                {
                    BelongsTo = (uint) CollisionLayers.Selection,
                    CollidesWith = (uint) CollisionLayers.Ground
                }
            };

            return _physicsWorld.CastRay(raycastInput, out hit);
        }
    }
}