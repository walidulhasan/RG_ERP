using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblSupplierToCostCenterAssociation
    {
        public long Id { get; set; }
        public long Coaid { get; set; }
        public long LocationId { get; set; }
        public long CostCenterId { get; set; }
        public long ActivityId { get; set; }
        public int? DomainId { get; set; }
    }
}
