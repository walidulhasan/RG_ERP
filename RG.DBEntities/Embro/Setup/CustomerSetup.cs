using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Setup
{
    public partial class CustomerSetup
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string SalesTaxNumber { get; set; }
        public string NationalTaxNumber { get; set; }
    }
}
