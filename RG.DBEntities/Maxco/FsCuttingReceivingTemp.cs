using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsCuttingReceivingTemp
    {
        public int Id { get; set; }
        public int FsIssuanceMasterId { get; set; }
        public int FsReceivingLotsVariationId { get; set; }
        public DateTime? Date { get; set; }
        public string ReceivingNumber { get; set; }
    }
}
