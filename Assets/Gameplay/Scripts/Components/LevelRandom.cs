using Unity.Entities;
using Unity.Mathematics;

namespace DOTS.Components
{
    public struct LevelRandom : IComponentData
    {
        public Random Value;
    }
}