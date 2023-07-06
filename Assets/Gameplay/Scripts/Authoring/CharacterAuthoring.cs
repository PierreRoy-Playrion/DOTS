using DOTS.Components;
using DOTS.Components.Tags;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DOTS.Authoring
{
    public class CharacterAuthoring : MonoBehaviour
    {
        public float MinSpeed = 2;
        public float MaxSpeed = 4;
    }

    public class CharacterBaker : Baker<CharacterAuthoring>
    {
        public override void Bake(CharacterAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            
            AddComponent(entity, new RandomSpeed
            {
               MinSpeed = authoring.MinSpeed,
               MaxSpeed = authoring.MaxSpeed
            });

            AddComponent(entity, new Destination
            {
                Position = float3.zero,
                IsValid = false
            });
            
            AddComponent<PlayerControlledTag>(entity);
        }
    }
}