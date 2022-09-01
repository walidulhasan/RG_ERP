using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.Business;

namespace RG.DBEntities.Maxco
{
    public partial class SeriesColors
    {
        public int Id { get; set; }
        public int SeriesId { get; set; }
        public byte FabricColorMatchingSourceId { get; set; }
        public byte ColorPalleteTypeId { get; set; }
        public string PantoneNo { get; set; }
        public string BuyerColorName { get; set; }

        public virtual ColorPalleteType_Setup ColorPalleteType { get; set; }
        public virtual FabricColorMatchingSource_Setup FabricColorMatchingSource { get; set; }
        public virtual Series Series { get; set; }
    }
}
