using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Business
{
    public partial class BankVoucherInfo
    {
        [Key,Column(Order=0)]
        public decimal VoucherID { get; set; }
        [Key, Column(Order = 1)]
        public decimal AccountID { get; set; }
        public string InstrumentID { get; set; }
        public string InstrumentNo { get; set; }
        public DateTime? VoucherDate { get; set; }
        public DateTime? DepositDate { get; set; }
        public string TreasuryChallanNo { get; set; }
        public string PropertyAddress { get; set; }
        public string PayeeResident { get; set; }
        public decimal? ProfitonDebt { get; set; }
        public string BorCA { get; set; }
        public decimal? ProfessionalFees { get; set; }
        public decimal? InstrumentTypeID { get; set; }
        public string RefNo { get; set; }
        public int? VIndex { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
