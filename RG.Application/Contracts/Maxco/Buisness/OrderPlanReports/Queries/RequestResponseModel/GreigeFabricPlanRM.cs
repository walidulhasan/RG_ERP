using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
    public class GreigeFabricPlanRM
    {
        public int BuyerID { get; set; }
        public string Buyer { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public int NumberOfGarments { get; set; }
        public decimal FirstRequiredQty { get; set; }
        public decimal DiffFabricQty { get; set; }
        public string AdditionalType { get; set; }
        public string KrsNo { get; set; }
        public decimal KRSQuantity { get; set; }
        public decimal RequiredQuantityWastageKG { get; set; }
        public decimal YarnIssue { get; set; }
        public decimal YarnBalance { get; set; }
        public decimal GreigeProduceQty { get; set; }//
        public decimal KnittingBalance { get; set; }
        public decimal GreigeIssueQty { get; set; }
        public DateTime? KnittingCloseDate { get; set; }
        public string KnittingCloseDateMsg { get {return KnittingCloseDate == null ? "" : KnittingCloseDate.Value.ToString("dd-MMM-yyyy"); } }
        public decimal BatchQty { get; set; }
        public decimal BatchBalance { get; set; }
        public DateTime? LastBatchDate { get; set; }
        public string LastBatchDateMsg { get { return LastBatchDate == null ? "" : LastBatchDate.Value.ToString("dd-MMM-yyyy"); } }
        public decimal FinishedQty { get; set; }
        public decimal DyedIssue { get; set; }
        public decimal DyedIssueAdjust { get; set; }

    }
}
