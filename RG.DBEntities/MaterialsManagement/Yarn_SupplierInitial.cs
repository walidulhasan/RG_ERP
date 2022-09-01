using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Yarn_SupplierInitial
    {
        [Key]
        public int Yarn_SupplierInitialID { get; set; }
        public int SupplierID { get; set; }
        public string Initial { get; set; }
    }
}
