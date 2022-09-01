using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Maxco.Business
{
    public class OrderKnittingScheduling:DefaultTableProperties
    {
        public int KnittingScheduleID { get; set; }
        [ForeignKey("OrderScheduling")]
        public int ScheduleID { get; set; }
        public int KRSID { get; set; }
        public int FabID { get; set; }
        public DateTime ScheduleDate { get; set; }
        public decimal Quantity { get; set; }
        public virtual OrderScheduling OrderScheduling { get; set; }
    }
}
