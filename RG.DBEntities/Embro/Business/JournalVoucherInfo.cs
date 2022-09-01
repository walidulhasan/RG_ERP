using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Business
{
    public partial class JournalVoucherInfo
    {
        public int Id { get; set; }
        [ForeignKey("Voucher")]
        public decimal? VoucherID { get; set; }
        public int? ItemID { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Rate { get; set; }
        public int? Vindex { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
