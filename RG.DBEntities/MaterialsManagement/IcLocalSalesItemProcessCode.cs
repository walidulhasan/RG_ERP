using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcLocalSalesItemProcessCode
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public long LocalSalesItemId { get; set; }
        public long AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
    }
}
