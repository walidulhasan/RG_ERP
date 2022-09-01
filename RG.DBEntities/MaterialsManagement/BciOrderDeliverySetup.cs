using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciOrderDeliverySetup
    {
        [Key]
        public long OrderDeliveryId { get; set; }
        public string Description { get; set; }
    }
}
