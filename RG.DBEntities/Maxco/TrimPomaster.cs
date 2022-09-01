using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class TrimPomaster
    {
        public TrimPomaster()
        {
            TrimPodetail = new HashSet<TrimPodetail>();
        }
        public int Id { get; set; }
        public int Tpomid { get; set; }
        public string Pono { get; set; }
        public DateTime Podate { get; set; }
        public short VendorSetupId { get; set; }
        public string Person { get; set; }
        public string Prreference { get; set; }
        public string QuotationReference { get; set; }
        public int ModeOfPaymentId { get; set; }
        public int TermsOfPaymentId { get; set; }
        public int Status { get; set; }

        public virtual ModeOfPaymentSetup ModeOfPayment { get; set; }
        public virtual TermOfPaymentSetup TermsOfPayment { get; set; }
        public virtual Vendor_setup VendorSetup { get; set; }
        public virtual ICollection<TrimPodetail> TrimPodetail { get; set; }
    }
}
