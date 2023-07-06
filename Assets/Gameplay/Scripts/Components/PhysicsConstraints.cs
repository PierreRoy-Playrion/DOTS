using Unity.Entities;
using Unity.Mathematics;

namespace DOTS.Components
{
    public struct PhysicsConstraints : IComponentData
    {
        public bool3 LinearLocks;
        public bool3 AngularLocks;
    }
}