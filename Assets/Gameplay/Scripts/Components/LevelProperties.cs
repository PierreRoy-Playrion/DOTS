using Unity.Entities;
using Unity.Mathematics;

namespace DOTS.Components
{
    public struct LevelProperties : IComponentData
    {
        public float2 Dimensions;
        public int MaxCharacterCount;
        public int MaxCharacterSpawnPointCount;
        public Entity CharacterPrefab;
        public Entity SpawnPointPrefab;
    }
}