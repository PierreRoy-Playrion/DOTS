using Unity.Burst;
using Unity.Entities;

namespace DOT.Systems
{
    public partial struct NavMeshPathfindingSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            // var navMeshWorld = NavMeshWorld.GetDefaultWorld();
            // var query = new NavMeshQuery(navMeshWorld, Allocator.Temp, 100);
            //
            // foreach (var (destination, transform) in SystemAPI.Query<RefRO<Destination>, RefRO<LocalTransform>>())
            // {
            //     if (!destination.IsValid)
            //         continue;
            //
            //     var currentPosition = query.MapLocation(transform.ValueRO.Position, Vector3.one * 100, 0);
            //     var destinationPosition = query.MapLocation(transform.ValueRO.Position, Vector3.one * 100, 0);
            //     query.BeginFindPath(currentPosition, destinationPosition);
            // }
        }
    }
}