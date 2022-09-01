using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel
{
    public class PendingDyeingLotsRM
    {
        public string Companyname { get; set; }
        public string CompanyShortName { get; set; }
        public string BuyerName { get; set; }
        public string OrderNo { get; set; }
        public string LotNo { get; set; }
        public string Color { get; set; }
        public string Machine { get; set; }
        public decimal GreigeQty { get; set; }
        public string LotDate { get; set; }
        public decimal FinishQty { get; set; }
        public decimal Delivered { get; set; }
        public int Overdue { get; set; }
        public string Remarks { get; set; }
    }
}
