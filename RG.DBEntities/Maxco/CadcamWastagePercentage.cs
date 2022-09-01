using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.Setup;

namespace RG.DBEntities.Maxco
{
    public partial class CadcamWastagePercentage
    {
        public int Id { get; set; }
        public int FabricWastageId { get; set; }
        public int Percentage { get; set; }
        public long RangeFrom { get; set; }
        public long RangeTo { get; set; }

        public virtual CadcamFinishedFabricWastageSetup FabricWastage { get; set; }
    }
}
