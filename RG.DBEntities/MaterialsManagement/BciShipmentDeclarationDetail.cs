using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciShipmentDeclarationDetail
    {
        public int Id { get; set; }
        public int BciShipmentDeclarationMasterId { get; set; }
        public int BciItemDescriptionSetupId { get; set; }
        public double Quantity { get; set; }
        public int BciItemUnitSetupId { get; set; }

        public virtual BciShipmentDeclarationMaster BciShipmentDeclarationMaster { get; set; }
    }
}
