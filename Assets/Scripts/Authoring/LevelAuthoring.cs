using DOTS.Components;
using Unity.Entities;
using UnityEngine;

namespace DOTS.Authoring
{
    public class LevelAuthoring : MonoBehaviour
    {
        public int MaxCharacterCount;
    }
    
    public class LevelBaker : Baker<LevelAuthoring>
    {
        public override void Bake(LevelAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            
            AddComponent(entity, new LevelProperties
            {
                MaxCharacterCount = authoring.MaxCharacterCount
            });
        }
    }
}