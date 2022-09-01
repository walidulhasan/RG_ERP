using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblKnittingYarnReturnDetail
    {
        public long ReturnDetailId { get; set; }
        public long ReturnId { get; set; }
        public long AttributeInstanceId { get; set; }
        public double ReturnQuantity { get; set; }
    }
}
