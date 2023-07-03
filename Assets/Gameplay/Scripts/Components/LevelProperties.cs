using Unity.Entities;

namespace DOTS.Components
{
    public struct LevelProperties : IComponentData
    {
        public int Dimensions;
        public int MaxCharacterCount;
        public Entity CharacterPrefab;
    }
}