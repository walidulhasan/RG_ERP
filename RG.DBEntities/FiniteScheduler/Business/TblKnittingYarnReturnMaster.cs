using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblKnittingYarnReturnMaster
    {
        public long ReturnId { get; set; }
        public long YarnKnittingContractId { get; set; }
        public DateTime CreationDate { get; set; }
        public int? Status { get; set; }
    }
}
