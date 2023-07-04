using DOTS.Blobs;
using Unity.Entities;

namespace DOTS.Components
{
    public struct LevelData : IComponentData
    {
        public BlobAssetReference<CharacterSpawnPointBlob> CharacterSpawnPoints;
    }
}