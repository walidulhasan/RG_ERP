using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciShipmentModeDetail
    {
        public int Id { get; set; }
        public int ShipmentModeId { get; set; }
        public string Description { get; set; }

        public virtual BciShipmentMode ShipmentMode { get; set; }
    }
}
