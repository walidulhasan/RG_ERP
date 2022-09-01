using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnKnittingContractClosureDetail
    {
        public int Id { get; set; }
        public string VoucherNumber { get; set; }
        public long YarnKncontractId { get; set; }
        public double GreigeRate { get; set; }
        public double GreigeQuantity { get; set; }
        public int ClosureStatus { get; set; }
    }
}
