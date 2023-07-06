using DOTS.Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;

namespace DOT.Systems
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct PhysicsConstraintsSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<PhysicsConstraints>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;

            var ecb = new EntityCommandBuffer(Allocator.Temp);
            
            foreach (var (constraints, entity) in SystemAPI.Query<RefRO<PhysicsConstraints>>().WithEntityAccess())
            {
                var joint = PhysicsJoint.CreateLimitedDOF(
                    RigidTransform.identity,
                    constraints.ValueRO.LinearLocks,
                    constraints.ValueRO.AngularLocks);
                
                ecb.AddComponent(entity, joint);
                ecb.AddComponent(entity, new PhysicsConstrainedBodyPair(entity, Entity.Null, false));
                ecb.RemoveComponent<PhysicsConstraints>(entity);
            }
            
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}