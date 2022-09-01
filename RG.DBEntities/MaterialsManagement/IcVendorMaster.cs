using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcVendorMaster
    {
        public long Id { get; set; }
        public string VendorName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public double? SumDeposit { get; set; }
        public long? AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
    }
}
