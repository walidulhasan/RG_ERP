using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Maxco.Business
{
    public class OrderSewingScheduling:DefaultTableProperties
    {
        public int SewingScheduleID { get; set; }
        [ForeignKey("OrderScheduling")]
        public int ScheduleID { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int FabricQualityID { get; set; }
        public string FabricComposition { get; set; }
        public int GSM { get; set; }
        public decimal FinishedWidth { get; set; }
        public string PantoneNo { get; set; }
        public int Quantity { get; set; }
        public decimal WastagePercent { get; set; }
        public virtual OrderScheduling OrderScheduling { get; set; }
    }
}
