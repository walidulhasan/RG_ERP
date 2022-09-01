using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class CheckIfVoucherBelongsToDiffCompanyForMaxco
    {
        public decimal VoucherId { get; set; }
        public DateTime? VoucherDate { get; set; }
        public int AccountId { get; set; }
        public decimal? AmountSum { get; set; }
    }
}
