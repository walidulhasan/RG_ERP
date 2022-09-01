using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsCuttingIssuance
    {
        public int Id { get; set; }
        public int FsCuttingReceivingId { get; set; }
        public DateTime Date { get; set; }
        public int FsReceivingLotsVariationId { get; set; }
        public string CuttingIssuanceNumber { get; set; }
    }
}
