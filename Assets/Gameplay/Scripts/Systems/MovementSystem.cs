using DOTS.Aspects;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace DOT.Systems
{
    [BurstCompile]
    [UpdateAfter(typeof(PlayerInputSystem))]
    public partial struct MovementSystem : ISystem
    {
        private const float tolerance = 0.1f;
        
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var agent in SystemAPI.Query<NavMeshAgentAspect>())
            {
                if (!agent.Destination.IsValid)
                    continue;

                var targetPos = agent.Destination.Position;
            
                if (math.distancesq(agent.Position, targetPos) < tolerance)
                    continue;
            
                var dirToTarget = targetPos - agent.Position;
                var moveDir = math.normalize(dirToTarget) * agent.Speed;
                agent.Move(moveDir);
            }
        }
    }
}