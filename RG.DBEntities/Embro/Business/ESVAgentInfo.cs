using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Embro.Business
{
    public class ESVAgentInfo
    {
        [ForeignKey("Voucher")]
        public decimal VoucherID { get; set; }
        public int CommissionAgentID { get; set; }
        public float? CommissionPercent { get; set; }
        public float? TamountinRs { get; set; }
        public string Currency { get; set; }
        public decimal? ConvRate { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
