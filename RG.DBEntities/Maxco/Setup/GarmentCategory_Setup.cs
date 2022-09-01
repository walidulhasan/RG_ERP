using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class GarmentCategory_Setup
    {
        public GarmentCategory_Setup()
        {
            ChainDailyProduction = new HashSet<ChainDailyProduction>();
            ChainOperationsGarment = new HashSet<ChainOperationsGarment>();
            GarmentTypeSetup = new HashSet<GarmentType_Setup>();
        }

        public byte ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ChainDailyProduction> ChainDailyProduction { get; set; }
        public virtual ICollection<ChainOperationsGarment> ChainOperationsGarment { get; set; }
        public virtual ICollection<GarmentType_Setup> GarmentTypeSetup { get; set; }
    }
}
