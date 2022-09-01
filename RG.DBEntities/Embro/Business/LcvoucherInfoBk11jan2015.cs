using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class LcvoucherInfoBk11jan2015
    {
        public long LcdetailId { get; set; }
        public decimal VoucherId { get; set; }
        public DateTime BankAcceptanceDate { get; set; }
        public DateTime BankMaturityDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LcvoucherCreationDate { get; set; }
    }
}
