using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class MaterialPomaster
    {
        public MaterialPomaster()
        {
            MaterialReceiptMaster = new HashSet<MaterialReceiptMaster>();
        }
        [Key]
        public int Mpmid { get; set; }
        public string Pono { get; set; }
        public DateTime Podate { get; set; }
        public int? VendorId { get; set; }
        public int ModeOfPaymentId { get; set; }
        public int TermsOfPaymentId { get; set; }
        public int Status { get; set; }
        public int? CartageId { get; set; }
        public int? DestinationId { get; set; }
        public DateTime? CancelDate { get; set; }
        public int? BrokerId { get; set; }
        public string RequisitionNo { get; set; }

        public virtual ModeOfPaymentSetup ModeOfPayment { get; set; }
        public virtual TermOfPaymentSetup TermsOfPayment { get; set; }
        public virtual ICollection<MaterialReceiptMaster> MaterialReceiptMaster { get; set; }
    }
}
