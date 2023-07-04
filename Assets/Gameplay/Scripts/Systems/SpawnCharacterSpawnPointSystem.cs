using DOTS.Aspects;
using DOTS.Blobs;
using DOTS.Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace DOT.Systems
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct SpawnCharacterSpawnPointSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<LevelProperties>();
            state.RequireForUpdate<LevelData>();
        }
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;

            var levelEntity = SystemAPI.GetSingletonEntity<LevelProperties>();
            var level = SystemAPI.GetAspect<LevelAspect>(levelEntity);

            // Create blob asset for storing instantiated spawn points
            using var blobBuilder = new BlobBuilder(Allocator.Temp);
            ref var spawnPointBlob = ref blobBuilder.ConstructRoot<CharacterSpawnPointBlob>();
            var spawnPointArray = blobBuilder.Allocate(ref spawnPointBlob.Array, level.MaxCharacterSpawnPointCount);
            Debug.Log("[DEBUG] Blob Asset created!");

            var ecb = new EntityCommandBuffer(Allocator.Temp);
            
            for (int i = 0; i < level.MaxCharacterSpawnPointCount; i++)
            {
                var spawnPoint = ecb.Instantiate(level.SpawnPointPrefab);
                var spawnPointTransform = level.GetRandomTransform();
                ecb.SetComponent(spawnPoint, spawnPointTransform);
                spawnPointArray[i] = spawnPointTransform.Position;
            }

            // Assign blob asset to blob asset reference in Level Data
            var levelData = SystemAPI.GetSingleton<LevelData>();
            levelData.CharacterSpawnPoints = blobBuilder.CreateBlobAssetReference<CharacterSpawnPointBlob>(Allocator.Persistent);
            SystemAPI.SetSingleton(levelData);
            Debug.Log("[DEBUG] Blob Asset assigned!");
            
            ecb.Playback(state.EntityManager);
        }
        
        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}