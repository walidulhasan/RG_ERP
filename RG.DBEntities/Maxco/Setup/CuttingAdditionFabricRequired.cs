using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Maxco.Setup
{
    public class CuttingAdditionFabricRequired : DefaultTableProperties
    {
        public int ID { get; set; }
        public long OrderID { get; set; }
        public DateTime RequisitionDate { get; set; }
        public decimal RequisitionQuantity { get; set; }
        public decimal PlanQuantity { get; set; }  
    }
}
