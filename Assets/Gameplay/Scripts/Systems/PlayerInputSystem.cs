using Unity.Burst;
using Unity.Entities;

namespace DOT.Systems
{
    public partial struct PlayerInputSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
        }
        
        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}