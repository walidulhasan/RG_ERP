using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class Greige_DyeingContractDeliverySchedule
    {
        public long ID { get; set; }
        //[ForeignKey("Greige_DyeingContractMaster")]
        public long DCID { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double Weight { get; set; }
        public int DeliveryLocationID { get; set; }
        //public virtual Greige_DyeingContractMaster Greige_DyeingContractMaster { get; set; }
    }
}
