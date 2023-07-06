using Unity.Entities;

namespace DOTS.Components
{
    public struct RandomSpeed : IComponentData
    {
        public float MinSpeed;
        public float MaxSpeed;
    }
}