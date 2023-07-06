using DOTS.Aspects;
using DOTS.Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace DOT.Systems
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct SetRandomSpeedSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<LevelProperties>();
            state.RequireForUpdate<RandomSpeed>();
        }

        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;

            var ecb = new EntityCommandBuffer(Allocator.Temp);
            var levelEntity = SystemAPI.GetSingletonEntity<LevelProperties>();
            var level = SystemAPI.GetAspect<LevelAspect>(levelEntity);

            foreach (var (random, entity) in SystemAPI.Query<RefRW<RandomSpeed>>().WithEntityAccess())
            {
                ecb.AddComponent(entity, new Speed
                {
                    Value = level.Random.NextFloat(random.ValueRO.MinSpeed, random.ValueRO.MaxSpeed)
                });

                ecb.RemoveComponent<RandomSpeed>(entity);
            }
            
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}