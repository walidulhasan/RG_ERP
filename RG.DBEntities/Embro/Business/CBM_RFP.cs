using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.Embro.Business
{
    public class CBM_RFP
    {
        public CBM_RFP()
        {
            CbmRelateEcfRfpChqVoucher = new HashSet<CBM_Relate_ECF_RFP_CHQ_VOUCHER>();
            CbmRfpDetail = new HashSet<CBM_RFP_Detail>();
        }
        [Key]
        public decimal RFPID { get; set; }
        public string RFPNum { get; set; }
        public DateTime? RFPDate { get; set; }
        public decimal? LocationID { get; set; }
        public string RFPDescription { get; set; }
        public string PaymentMode { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? SupplierID { get; set; }
        public decimal? CompID { get; set; }
        public decimal? BusinessID { get; set; }
        public decimal? CreationBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public decimal? VerificationBy { get; set; }
        public DateTime? Verificationdate { get; set; }
        public decimal? CheckBy { get; set; }
        public DateTime? CheckDate { get; set; }
        public bool? IsAdvanceAdjusted { get; set; }
        public int? RFPAddedStatus { get; set; }
        public decimal? RelatedOldRFPID { get; set; }

        public virtual ICollection<CBM_Relate_ECF_RFP_CHQ_VOUCHER> CbmRelateEcfRfpChqVoucher { get; set; }
        public virtual ICollection<CBM_RFP_Detail> CbmRfpDetail { get; set; }
    }
}
