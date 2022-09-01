using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;


namespace RG.DBEntities.Maxco
{
    public partial class ChainHistoricalNmax
    {
        public int Id { get; set; }
        public byte GarmentId { get; set; }
        public int NMax { get; set; }
        public int NoOfStyles { get; set; }

        public virtual GarmentType_Setup Garment { get; set; }
    }
}
