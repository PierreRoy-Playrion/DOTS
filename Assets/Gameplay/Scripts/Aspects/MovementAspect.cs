using DOTS.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

namespace DOTS.Aspects
{
    public readonly partial struct MovementAspect : IAspect
    {
        public readonly Entity Entity;

        private readonly RefRW<LocalTransform> _transform;
        private readonly RefRW<PhysicsVelocity> _physicsVelocity;
        private readonly RefRO<Speed> _speed;

        public float3 Position => _transform.ValueRO.Position;
        public float Speed => _speed.ValueRO.Value;
        
        public void SetPhysicsLinearVelocity(float3 velocity)
        {
            _physicsVelocity.ValueRW.Linear = velocity;
        }
    }
}