using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsIssuanceMaster
    {
        public int Id { get; set; }
        public int FsReceivingLotsVariationId { get; set; }
        public DateTime Date { get; set; }
        public int? FsReceivingMasterId { get; set; }
        public string IssuanceNumber { get; set; }
    }
}
