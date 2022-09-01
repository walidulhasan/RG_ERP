using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class Country_Setup
    {
        public Country_Setup()
        {
            CitySetup = new HashSet<City_Setup>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<City_Setup> CitySetup { get; set; }
    }
}
