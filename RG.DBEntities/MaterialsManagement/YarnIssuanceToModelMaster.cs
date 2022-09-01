using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnIssuanceToModelMaster
    {
        public long Yisid { get; set; }
        public long? Frsid { get; set; }
        public string IssuanceDate { get; set; }
        public short? Status { get; set; }
        public long? KnitterId { get; set; }
        public string ChallanNo { get; set; }
        public string Lcno { get; set; }
        public int? NoOfCartons { get; set; }
        public long? OrderId { get; set; }
        public long? StyleId { get; set; }
        public long? CompanyId { get; set; }
        public int? BusinessId { get; set; }
    }
}
