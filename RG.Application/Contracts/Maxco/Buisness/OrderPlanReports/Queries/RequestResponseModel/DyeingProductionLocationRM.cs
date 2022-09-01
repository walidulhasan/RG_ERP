using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
    public class DyeingProductionLocationRM
    {
        public int OrderID { get; set; }
        public int ProductionUnit { get; set; }
        public string LocationName { get; set; }
        public decimal ProductionQuantity { get; set; }
        public DateTime ProductionDate { get; set; }

    }
}
