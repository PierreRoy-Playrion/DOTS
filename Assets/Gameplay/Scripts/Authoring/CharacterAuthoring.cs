using DOTS.Components;
using DOTS.Components.Tags;
using Unity.Entities;
using UnityEngine;

namespace DOTS.Authoring
{
    public class CharacterAuthoring : MonoBehaviour
    {
        public float Speed = 4;
    }

    public class CharacterBaker : Baker<CharacterAuthoring>
    {
        public override void Bake(CharacterAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            
            AddComponent(entity, new SpeedData
            {
                Value = authoring.Speed
            });

            AddComponent<PlayerControlledTag>(entity);
        }
    }
}