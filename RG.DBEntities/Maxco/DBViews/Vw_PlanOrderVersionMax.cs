using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Maxco.DBViews
{
    public class Vw_PlanOrderVersionMax
    {
        public int PlanVersionID { get; set; }
        public int PlanID { get; set; }
        public int VersionNo { get; set; }
        public DateTime VersionDate { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderReceiveDate { get; set; }
        public string OrderNo { get; set; }
        public int BuyerID { get; set; }
        public string Buyer { get; set; }

    }
}
