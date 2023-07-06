using DOTS.Components;
using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace DOTS.Authoring
{
    public class LevelAuthoring : MonoBehaviour
    {
        public Vector2 Dimensions;
        public int MaxCharacterCount;
        public int MaxCharacterSpawnPointCount;
        public GameObject CharacterPrefab;
        public GameObject SpawnPointPrefab;
        public uint RandomSeed;
    }
    
    public class LevelBaker : Baker<LevelAuthoring>
    {
        public override void Bake(LevelAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.WorldSpace);
            
            AddComponent(entity, new LevelProperties
            {
                Dimensions = authoring.Dimensions,
                MaxCharacterCount = authoring.MaxCharacterCount,
                MaxCharacterSpawnPointCount = authoring.MaxCharacterSpawnPointCount,
                CharacterPrefab = GetEntity(authoring.CharacterPrefab, TransformUsageFlags.Dynamic), 
                SpawnPointPrefab = GetEntity(authoring.SpawnPointPrefab, TransformUsageFlags.WorldSpace) 
            });

            AddComponent(entity, new LevelRandom
            {
                Value = Random.CreateFromIndex(authoring.RandomSeed)
            });
            
            AddComponent<LevelData>(entity);
        }
    }
}