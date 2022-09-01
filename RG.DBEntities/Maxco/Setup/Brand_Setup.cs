using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class Brand_Setup
    {
        [Key]
        public long BrandID { get; set; }
        public int SupplierID { get; set; }
        public string Description { get; set; }
    }
}
