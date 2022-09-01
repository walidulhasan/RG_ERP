using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnIssuanceToModelQtyDetail
    {
        public long Id { get; set; }
        public long? IssuanceMasterId { get; set; }
        public long? FrsattributeInstanceId { get; set; }
        public long? NewAttributeInstanceId { get; set; }
        public int? IsContaminated { get; set; }
    }
}
