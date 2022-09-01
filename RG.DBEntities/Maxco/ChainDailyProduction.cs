using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
    using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class ChainDailyProduction
    {
        public int Id { get; set; }
        public byte GarmentCategoryId { get; set; }
        public int Day { get; set; }
        public float? Production { get; set; }
        public int? NoOfStyles { get; set; }

        public virtual GarmentCategory_Setup GarmentCategory { get; set; }
    }
}
