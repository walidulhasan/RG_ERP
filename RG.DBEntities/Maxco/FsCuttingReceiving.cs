using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsCuttingReceiving
    {
        public int Id { get; set; }
        public int? FsIssuanceMasterId { get; set; }
        public int FsReceivingLotsVariationId { get; set; }
        public DateTime? Date { get; set; }
        public string ReceivingNumber { get; set; }
        public long? TempCuttingReceivingId { get; set; }
        public long? ReqSheetId { get; set; }
    }
}
