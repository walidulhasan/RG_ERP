using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsCuttingWastage
    {
        public int Id { get; set; }
        public int FsCuttingIssuanceId { get; set; }
        public int FsReceivingLotsVariationId { get; set; }
        public string CuttingWastageNumber { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
    }
}
