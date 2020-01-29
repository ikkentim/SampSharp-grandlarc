using SampSharp.Entities.SAMP;

namespace GrandLarcency
{
    public struct VehicleSpawn
    {
        public VehicleModelType Model { get; set; }
        public Vector3 Postion { get; set; }
        public float Angle { get; set; }
        public int Color1 { get; set; }
        public int Color2 { get; set; }
    }
}