using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FsIssuanceMaster
    {
        public long IssuanceMasterId { get; set; }
        public string IssuanceChallanNo { get; set; }
        public int UserId { get; set; }
        public DateTime Dated { get; set; }
        public int IssuanceFrom { get; set; }
        public int IssuedTo { get; set; }
        public long StyleId { get; set; }
        public string Comments { get; set; }
        public int ChallanStatusId { get; set; }
        public long? StitchingJobId { get; set; }
        public int? IsBarCode { get; set; }
        public bool? IsReceived { get; set; }
    }
}
