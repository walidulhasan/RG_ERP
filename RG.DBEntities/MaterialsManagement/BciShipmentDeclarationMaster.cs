using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciShipmentDeclarationMaster
    {
        public BciShipmentDeclarationMaster()
        {
            BciShipmentDeclarationDetail = new HashSet<BciShipmentDeclarationDetail>();
        }

        public int Id { get; set; }
        public int BciItemSetupId { get; set; }
        public int NoofItemDescription { get; set; }

        public virtual ICollection<BciShipmentDeclarationDetail> BciShipmentDeclarationDetail { get; set; }
    }
}
