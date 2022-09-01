using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Business
{
    public partial class Voucherdetail
    {
        [Key]
        public long VID { get; set; }
        [ForeignKey("Voucher")]
        public decimal VoucherID { get; set; }
        public int AccountID { get; set; }
        public decimal Amount { get; set; }
        public int? LocationID { get; set; }
        public string Status { get; set; }
        public long? Costcenter { get; set; }
        public long? Activity { get; set; }
        public int? Vindex { get; set; }       
        public long? EntryType { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}
