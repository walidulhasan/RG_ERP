using RG.DBEntities.Embro.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Setup
{
    public partial class SupplierSetup
    {
        public SupplierSetup()
        {
            //ApmPaymentModesDetail = new HashSet<ApmPaymentModesDetail>();
            //ApmSupplierPaymentTerms = new HashSet<ApmSupplierPaymentTerms>();
        }

        public decimal ID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string SalesTaxRegNumber { get; set; }
        public string NTNNumber { get; set; }
        public string Comments { get; set; }
        public string SupplierType { get; set; }

        //public virtual ICollection<ApmPaymentModesDetail> ApmPaymentModesDetail { get; set; }
        //public virtual ICollection<ApmSupplierPaymentTerms> ApmSupplierPaymentTerms { get; set; }
    }
}
