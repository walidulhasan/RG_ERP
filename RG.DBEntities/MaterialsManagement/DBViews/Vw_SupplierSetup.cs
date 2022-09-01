using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.DBViews
{
    public class Vw_SupplierSetup
    {
        public Decimal ID { get; set; }
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
                       
    }
}
