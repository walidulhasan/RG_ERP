using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciShippersSetup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string SalesTaxNo { get; set; }
        public string PhoneNo { get; set; }
    }
}
