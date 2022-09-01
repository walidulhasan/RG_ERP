using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel
{
    public class KnittingDailyNotificationRM
    {
        public long SerialNo { get; set; }
        public long CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int Machine { get; set; }
        public string Brand { get; set; }
        public string FabricType { get; set; }
        public string FabricQuality { get; set; }
        public string FabricComposition { get; set; }
        public int Gsm { get; set; }
        public long Width { get; set; }
        public double ShiftA { get; set; }
        public double ShiftB { get; set; }
        public double ShiftC { get; set; }
        public double TotalQty { get; set; }
    }
}
