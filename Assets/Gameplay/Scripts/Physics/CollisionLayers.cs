using System;

namespace DOTS.Physics
{
    [Flags]
    public enum CollisionLayers
    {
        Selection = 1 << 0,
        Ground = 1 << 1,
        Character = 1 << 2
    }
}