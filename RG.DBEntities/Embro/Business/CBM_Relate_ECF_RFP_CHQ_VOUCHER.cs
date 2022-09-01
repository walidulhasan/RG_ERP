using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Embro.Business
{
    public class CBM_Relate_ECF_RFP_CHQ_VOUCHER 
    {
        [Key]
        public long VID { get; set; }
        [ForeignKey("Voucher")]
        public decimal VoucherID { get; set; }
        [ForeignKey("CBM_ECF")]
        public decimal? ECFID { get; set; }
        [ForeignKey("CBM_RFP")]
        public decimal? RFPID { get; set; }
        [ForeignKey("CBM_LRP")]
        public decimal? LRPID { get; set; }        
        public decimal? ChqID { get; set; }
        public DateTime? AdjustmentDate { get; set; }


        public virtual CBM_ECF CBM_ECF { get; set; }
        public virtual CBM_LRP CBM_LRP { get; set; }
        public virtual CBM_RFP CBM_RFP { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}
