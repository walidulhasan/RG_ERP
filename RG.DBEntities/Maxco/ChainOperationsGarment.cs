using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;

namespace RG.DBEntities.Maxco
{
    public partial class ChainOperationsGarment
    {
        public int Id { get; set; }
        public int ChainOperationId { get; set; }
        public byte GarmentCategoryId { get; set; }

        public virtual GarmentCategory_Setup GarmentCategory { get; set; }
    }
}
