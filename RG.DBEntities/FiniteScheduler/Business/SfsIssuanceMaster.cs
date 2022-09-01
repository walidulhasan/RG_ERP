using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsIssuanceMaster
    {
        public long IssuanceId { get; set; }
        public long JobId { get; set; }
        public long StyleId { get; set; }
        public DateTime IssuanceDate { get; set; }
        public int Deleted { get; set; }
        public string Comments { get; set; }
        public int? IsBarCode { get; set; }
    }
}
