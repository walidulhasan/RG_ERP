using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciAssortmentCodeSetupDetail
    {
        public int Id { get; set; }
        public int AssortmentCodeSetupMasterId { get; set; }
        public int SizeId { get; set; }
        public int Quantity { get; set; }
        public int? ColorId { get; set; }

        public virtual BciAssortmentCodeSetupMaster AssortmentCodeSetupMaster { get; set; }
    }
}
