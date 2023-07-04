using DOTS.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace DOTS.Aspects
{
    /// <summary>
    /// Groups Level related components.
    /// </summary>
    public readonly partial struct LevelAspect : IAspect
    {
        public readonly Entity Entity;

        private readonly RefRO<LocalToWorld> _transform;
        private readonly RefRO<LevelProperties> _properties;
        private readonly RefRW<LevelRandom> _random;
        private readonly RefRW<LevelData> _data;

        public LevelData Data => _data.ValueRW;
        
        public int MaxCharacterSpawnPointCount => _properties.ValueRO.MaxCharacterSpawnPointCount;
        public Entity SpawnPointPrefab => _properties.ValueRO.SpawnPointPrefab;
        public Entity CharacterPrefab => _properties.ValueRO.CharacterPrefab;
        
        private float3 MinCorner => _transform.ValueRO.Position - HalfDimensions;
        private float3 MaxCorner => _transform.ValueRO.Position + HalfDimensions;

        private float3 HalfDimensions => new()
        {
            x = _properties.ValueRO.Dimensions.x * 0.5f,
            z = _properties.ValueRO.Dimensions.y * 0.5f,
            y = 0
        };
        
        public LocalTransform GetRandomTransform()
        {
            return new LocalTransform
            {
                Position = GetRandomPosition(),
                Rotation = quaternion.identity,
                Scale = 1f
            };
        }

        private float3 GetRandomPosition()
        {
            return _random.ValueRW.Value.NextFloat3(MinCorner, MaxCorner);
        }
    }
}