using Unity.Entities;
using Unity.Mathematics;

namespace DOTS.Components
{
    public struct Destination : IComponentData
    {
        public bool IsValid;
        public float3 Position;
    }
}