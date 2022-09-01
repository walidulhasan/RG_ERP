using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Embro.Business
{
    public class LCVoucherInfo
    {
        [Key]
        public long LCDetailID { get; set; }
        [ForeignKey("Voucher")]
        public decimal VoucherID { get; set; }
        public DateTime BankAcceptanceDate { get; set; }
        public DateTime BankMaturityDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LcvoucherCreationDate { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
