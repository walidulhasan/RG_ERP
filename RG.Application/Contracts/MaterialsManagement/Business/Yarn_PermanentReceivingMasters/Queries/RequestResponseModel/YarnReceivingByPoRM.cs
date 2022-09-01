using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.Yarn_PermanentReceivingMasters.Queries.RequestResponseModel
{
    public class YarnReceivingByPoRM
    {
        public YarnReceivingByPoRM()
        {
            YarnRackAllocation = new List<YarnRackAllocationRM>();
        }
        public long YarnStockTransactionID { get; set; }
        public long POID { get; set; }
        public string PONo { get; set; }
        public DateTime? PODate { get; set; }
        public string PODateST { get { return PODate.HasValue == true ? PODate.Value.ToString("dd-MMM-yyyy") : ""; } }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }

        public string LotNo { get; set; }

        public string YarnComposition { get; set; }
        public string YarnCount { get; set; }
        public string YarnQuality { get; set; }
        public string YarnColor { get; set; }

        public long YarnPermRecID { get; set; }
        public string YarnPermRecNo { get; set; }
        public DateTime? YarnPermRecDate { get; set; }
        public string YarnPermRecDateST { get { return YarnPermRecDate.HasValue == true ? YarnPermRecDate.Value.ToString("dd-MMM-yyyy") : ""; } }
        public decimal TransactionQty { get; set; }
        public decimal AllocatedQty { get { return YarnRackAllocation.Sum(x => x.AllocatedQuantity); } }
        public List<YarnRackAllocationRM> YarnRackAllocation { get; set; }
    }

    public class YarnRackAllocationRM
    {
        public long RackAllocationID { get; set; }
        public long YarnStockTransactionID { get; set; }
        public int BuildingID { get; set; }
        public string BuildingName { get; set; }
        public int BuildingFloorID { get; set; }
        public string BuildingFloor { get; set; }
        public int RackID { get; set; }
        public string RackName { get; set; }
        public int SubRackID { get; set; }
        public string SubRackName { get; set; }
        public decimal AllocatedQuantity { get; set; }
        public decimal TotalRackAllocated { get; set; }
        public decimal? LimitRemaining { get; set; }
        public decimal SubRackLimitQuantity { get; set; }
        public bool IsIssuedFromBalance { get; set; }

    }
}
