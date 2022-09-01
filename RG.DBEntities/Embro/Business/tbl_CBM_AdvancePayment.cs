using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Embro.Business
{
    public class tbl_CBM_AdvancePayment
    {
        public tbl_CBM_AdvancePayment()
        {
            TblCbmAdvancePaymentRfpRelate = new HashSet<tbl_CBM_AdvancePayment_RFP_Relate>();
        }

        public decimal ID { get; set; }
        public decimal VoucherID { get; set; }
        public decimal AccountID { get; set; }
        public decimal? VID { get; set; }
        public decimal? VINDEX { get; set; }

        public virtual ICollection<tbl_CBM_AdvancePayment_RFP_Relate> TblCbmAdvancePaymentRfpRelate { get; set; }
    }
}
