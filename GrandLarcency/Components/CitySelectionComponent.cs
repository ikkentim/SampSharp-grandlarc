using System;
using SampSharp.Entities;

namespace GrandLarcency
{
    public class CitySelectionComponent : Component
    {
        public CitySelectionComponent()
        {
            LastSelection = DateTime.UtcNow;
            SelectedCity = City.None;
        }

        public DateTime LastSelection { get; set; }
        public City SelectedCity { get; set; }
    }
}