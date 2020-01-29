using SampSharp.Entities.SAMP;

namespace GrandLarcency
{
    public struct SpawnLocation
    {
        public SpawnLocation(Vector3 position, float angle)
        {
            Position = position;
            Angle = angle;
        }

        public Vector3 Position { get; }
        public float Angle { get; }
    }
}