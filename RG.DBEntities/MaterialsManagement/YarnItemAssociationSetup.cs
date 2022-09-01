using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnItemAssociationSetup
    {
        public long Id { get; set; }
        public long DocumentTypeId { get; set; }
        public long ItemId { get; set; }
        public long CompanyId { get; set; }
        public long CostCenter { get; set; }
        public long Location { get; set; }
        public long ActivityId { get; set; }
    }
}
