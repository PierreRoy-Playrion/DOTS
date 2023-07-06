using DOTS.Components;
using Unity.Entities;
using Unity.Mathematics;

namespace DOTS.Aspects
{
    public readonly partial struct NavMeshAgentAspect : IAspect
    {
        public readonly Entity Entity;

        public readonly MovementAspect _movement;
        public readonly RefRW<Destination> _destination;

        public Destination Destination => _destination.ValueRW;
        public float3 Position => _movement.Position;
        public float Speed => _movement.Speed;

        public void Move(float3 direction)
        {
            _movement.SetPhysicsLinearVelocity(direction);
        }
    }
}