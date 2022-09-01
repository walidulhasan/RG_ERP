using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.OrderKnittingSchedulings.Queries.RequestResponseModel
{
    public class OrderKnittingSchedulingRM
    {
        public int KnittingScheduleID { get; set; }
        public int ScheduleID { get; set; }
        public int KRSID { get; set; }
        public int FabID { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string ScheduleDateMsg { get { return ScheduleDate.ToString("dd-MMM-yyyy"); } }
        public decimal Quantity { get; set; }
        public string FabricType { get; set; }
        public string FabricQuality { get; set; }
        public string FabricComposition { get; set; }
        public int GSM { get; set; }
        public decimal FinishedWidth { get; set; }
    }
}
