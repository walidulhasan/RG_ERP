using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Embro.Business
{
    public class CBM_ECF
    {
        public CBM_ECF()
        {
            CBM_ECFDetail = new HashSet<CBM_ECFDetail>();
            CBM_Relate_ECF_RFP_CHQ_VOUCHER = new HashSet<CBM_Relate_ECF_RFP_CHQ_VOUCHER>();
        }
        [Key]
        public decimal ECFID { get; set; }
        public string ECFNum { get; set; }
        public DateTime? ECFDate { get; set; }
        public string ECFDescription { get; set; }
        public string ECFType { get; set; }
        public decimal? Claimant { get; set; }
        public decimal? Total { get; set; }
        public string PaymentMode { get; set; }
        public decimal? CompID { get; set; }
        public decimal? BusinessID { get; set; }
        public decimal? CreationBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public decimal? VerificationBy { get; set; }
        public DateTime? VerificationDate { get; set; }
        public decimal? ApprovalBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public virtual ICollection<CBM_ECFDetail> CBM_ECFDetail { get; set; }
        public virtual ICollection<CBM_Relate_ECF_RFP_CHQ_VOUCHER> CBM_Relate_ECF_RFP_CHQ_VOUCHER { get; set; }
    }
}
