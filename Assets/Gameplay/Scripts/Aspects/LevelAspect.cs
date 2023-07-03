using DOTS.Components;
using Unity.Entities;
using Unity.Transforms;

namespace Gameplay.Scripts.Aspects
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
    }
}