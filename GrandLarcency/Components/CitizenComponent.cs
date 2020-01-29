using SampSharp.Entities;

namespace GrandLarcency
{
    public class CitizenComponent : Component
    {
        public CitizenComponent(City city)
        {
            City = city;
        }

        public City City { get; set; }
    }
}