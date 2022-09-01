using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
    public class BatchCommitmentRM
    {
        public int OrderID { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime CommitmentDate { get; set; }
        public string CommitmentDateMsg { get; set; }
        public decimal CommitmentQuantity { get; set; }
    }
}
