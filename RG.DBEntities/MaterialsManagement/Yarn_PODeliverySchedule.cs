using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Yarn_PODeliverySchedule
    {
        [Key]
        public long YarnDelSchID { get; set; }
        public long Yarn_PODetailID { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double DeliveryQTY { get; set; }
        public double? Amount { get; set; }
        public double? CF { get; set; }
    }
}
