using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Embro.Business
{
    public class tbl_CBM_AdvancePayment_RFP_Relate
    {
        public int ID { get; set; }
        public decimal AdvancePaymentID { get; set; }
        public decimal InvoiceID { get; set; }
        public int RFPID { get; set; }
        public decimal AmountDeducted { get; set; }
        public DateTime? EntryTime { get; set; }

        public virtual tbl_CBM_AdvancePayment AdvancePayment { get; set; }
    }
}
