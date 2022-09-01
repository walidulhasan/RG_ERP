using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedCuttingPermanentReceivingSubDetail
    {
        public long SubDetailId { get; set; }
        public long DetailId { get; set; }
        public long RollId { get; set; }
        public string RollNo { get; set; }
        public double Quantity { get; set; }
    }
}
