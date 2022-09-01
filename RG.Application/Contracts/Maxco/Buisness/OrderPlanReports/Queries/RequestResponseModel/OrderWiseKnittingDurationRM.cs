using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
    public class OrderWiseKnittingDurationRM
    {
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public decimal GreigeQuantity { get; set; }
        public DateTime? KnittingStartDate { get; set; }
        public string KnittingStartDateSTR { get; set; }

        public DateTime? KnittingEndDate { get; set; }
        public string KnittingEndDateSTR { get; set; }

    }
}
