using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Embro.Business
{
    public partial class CBM_LRP
    {
        public CBM_LRP()
        {
            CBM_LRPDetail = new HashSet<CBM_LRP_Detail>();
            CBM_Relate_ECF_RFP_CHQ_VOUCHER = new HashSet<CBM_Relate_ECF_RFP_CHQ_VOUCHER>();
        }
        [Key]
        public decimal LRPID { get; set; }
        public string LRPNum { get; set; }
        public DateTime? LRPDate { get; set; }
        public decimal? LocationID { get; set; }
        public string LRPDescription { get; set; }
        public string PaymentMode { get; set; }
        public decimal? NetAmount { get; set; }
        public int LeasorID { get; set; }
        public decimal? CompID { get; set; }
        public decimal? BusinessID { get; set; }
        public decimal? CreationBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public decimal? VerificationBy { get; set; }
        public DateTime? Verificationdate { get; set; }
        public decimal? CheckBy { get; set; }
        public DateTime? CheckDate { get; set; }
        public decimal? VOUCHERID { get; set; }

        public virtual ICollection<CBM_LRP_Detail> CBM_LRPDetail { get; set; }
        public virtual ICollection<CBM_Relate_ECF_RFP_CHQ_VOUCHER> CBM_Relate_ECF_RFP_CHQ_VOUCHER { get; set; }
    }
}
