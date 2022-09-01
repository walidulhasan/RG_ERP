using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.YarnStockReport.RequestResponseModel
{
    public class YarnRackBalanceReportRM
    {
        public string LotNo { get; set; }
        public string CompanyName { get; set; }
        public string YarnComposition { get; set; }
        public string YarnCount { get; set; }
        public string YarnQuality { get; set; }
        public string YarnColor { get; set; }
        public long? SupplierID { get; set; }
        public long? AttributeInstanceID { get; set; }
        public DateTime? TransactionDate { get; set; }
        public double LotAge { get; set; }
        public decimal TransactionQty { get; set; }
        public int? SubRackID { get; set; }
        public string SubRackName { get; set; }
        public int? SubRackSerial { get; set; }
        public string RackShortName { get; set; }
        public int? RackSerial { get; set; }
        public string FloorName { get; set; }
        public string BuildingName { get; set; }
        public decimal SubRackBalanceQty { get; set; }
        public string SupplierName { get; set; }

        public long CompanyID { get; set; }
        /// <summary>
        ///  not show
        /// </summary>
        public decimal AllocatedQuantity { get; set; } = 0;
        public decimal IssuedQuantity { get; set; } = 0;
    }
}
