using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Business.DFS_StockTransactions.Queries.RequestResponseModel
{
    public class OrderWiseFabricStatusAndLotInfoSVM
    {
        public OrderWiseFabricStatusAndLotInfoSVM()
        {
            OrderFabrincWithLot = new List<OrderFabricInfo>();
        }
        public List<OrderFabricInfo> OrderFabrincWithLot { get; set; }


    }
    public class OrderFabricInfo
    {
        public OrderFabricInfo()
        {
            FabricLot = new List<OrderLotInfo>();
        }
        public DateTime ReportDate { get; set; }
        public string Buyer { get; set; }
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public string FabricType { get; set; }
        public string FabricQuality { get; set; }
        public string FabricComposition { get; set; }
        public decimal? FirstRequiredQty { get; set; }
        public decimal? LastRequiredQty { get; set; }
        public decimal? FabricVersionDiff { get; set; }
        public decimal? KRSQuantity { get; set; }
        public decimal? KRSQuantityWithWastage { get; set; }
        public decimal? GWS_PERCENTAGE { get; set; }
        public decimal? GreigeQty { get; set; }
        public decimal? BatchQty { get; set; }
        public decimal? FinishQty { get; set; }

        public List<OrderLotInfo> FabricLot { get; set; }
    }
    public class OrderLotInfo
    {
        public int OrderID { get; set; }
        public long LotID { get; set; }
        public string LotNo { get; set; }
        public string FabricType { get; set; }
        public string FabricQuality { get; set; }
        public string FabricComposition { get; set; }

        public decimal GreigeQty { get; set; }
        public DateTime? InspectionDate { get; set; }
        public decimal? FinishQty { get; set; }
        public decimal? WastageQty { get; set; }
        public decimal? WestagePercent { get; set; }
        public DateTime? ComtexDeliveryDate { get; set; }
        public DateTime? AopDeliveryDate { get; set; }



        public string DeliveryDateST
        {
            get
            {
                var DeliveryDate = ComtexDeliveryDate.HasValue == true ? ComtexDeliveryDate : AopDeliveryDate;

                return DeliveryDate.HasValue == true ? DeliveryDate.Value.ToString("dd-MMM-yyyy") : "";
            }
        }
        public string InspectionDateST { get { return InspectionDate.HasValue == true ? InspectionDate.Value.ToString("dd-MMM-yyyy") : ""; } }

    }


}
