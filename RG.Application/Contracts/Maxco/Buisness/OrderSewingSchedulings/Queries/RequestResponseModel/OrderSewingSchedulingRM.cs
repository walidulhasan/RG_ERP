using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderSewingSchedulings.Queries.RequestResponseModel
{
    public class OrderSewingSchedulingRM
    {
        public int SewingScheduleID { get; set; }
        public int ScheduleID { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string ScheduleDateMsg { get { return ScheduleDate.ToString("dd-MMM-yyyy"); } }
        public int FabricQualityID { get; set; }
        public string FabricComposition { get; set; }
        public int GSM { get; set; }
        public decimal FinishedWidth { get; set; }
        public string PantoneNo { get; set; }
        public int Quantity { get; set; }
        public decimal WastagePercent { get; set; }
        public string FabricQualityDescription { get; set; }
        public string FabricTypeDescription { get; set; }
       
    }
}
