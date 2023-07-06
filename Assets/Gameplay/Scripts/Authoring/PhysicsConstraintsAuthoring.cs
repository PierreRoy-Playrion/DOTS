using DOTS.Components;
using Unity.Entities;
using Unity.Entities.Hybrid.Baking;
using Unity.Mathematics;

namespace DOTS.Authoring
{
    public class PhysicsConstraintsAuthoring : BakingOnlyEntityAuthoring
    {
        public bool3 linearConstrains;
        public bool3 angularConstrains;
    }

    public class PhysicsConstraintsBaker : Baker<PhysicsConstraintsAuthoring>
    {
        public override void Bake(PhysicsConstraintsAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            
            AddComponent(entity, new PhysicsConstraints
            {
                LinearLocks = authoring.linearConstrains,
                AngularLocks = authoring.angularConstrains
            });
        }
    }
}