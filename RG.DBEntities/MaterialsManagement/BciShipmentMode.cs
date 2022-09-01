using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciShipmentMode
    {
        public BciShipmentMode()
        {
            BciShipmentModeDetail = new HashSet<BciShipmentModeDetail>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BciShipmentModeDetail> BciShipmentModeDetail { get; set; }
    }
}
