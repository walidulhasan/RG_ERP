using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DdsupplierDomain
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int ItemCatagoryId { get; set; }

        public virtual DditemCatagorySetup ItemCatagory { get; set; }
        public virtual Ddsupplier Supplier { get; set; }
    }
}
