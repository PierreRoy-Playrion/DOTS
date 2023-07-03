using DOTS.Components;
using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace DOTS.Authoring
{
    public class LevelAuthoring : MonoBehaviour
    {
        public int Dimensions;
        public int MaxCharacterCount;
        public GameObject CharacterPrefab;
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
                CharacterPrefab = GetEntity(authoring.CharacterPrefab, TransformUsageFlags.Dynamic) 
            });
            
            AddComponent(entity, new LevelRandom
            {
                Value = Random.CreateFromIndex(authoring.RandomSeed)
            });
        }
    }
}