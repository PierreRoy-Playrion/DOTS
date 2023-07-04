using DOTS.Aspects;
using DOTS.Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace DOT.Systems
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [UpdateAfter(typeof(SpawnCharacterSpawnPointSystem))]
    public partial struct SpawnCharacterSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<LevelData>();
        }
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;
            
            var levelEntity = SystemAPI.GetSingletonEntity<LevelData>();
            var level = SystemAPI.GetAspect<LevelAspect>(levelEntity);
            var spawnPoints = level.Data.CharacterSpawnPoints;

            var ecb = new EntityCommandBuffer(Allocator.Temp);

            for (int i = 0; i < spawnPoints.Value.Array.Length; i++)
            {
                var spawnPoint = spawnPoints.Value.Array[i];
                var spawnedCharacter = ecb.Instantiate(level.CharacterPrefab);
                
                ecb.SetComponent(spawnedCharacter, new LocalTransform
                {
                    Position = spawnPoint,
                    Rotation = quaternion.identity,
                    Scale = 1f
                });
            }
            
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
        
        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}