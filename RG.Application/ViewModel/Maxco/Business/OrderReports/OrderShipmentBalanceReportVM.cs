using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.Maxco.Business.OrderReports
{
    public class OrderShipmentBalanceReportVM
    {
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public int OrderQty { get; set; }
        public decimal CostingPrice { get; set; }
        public decimal CostingCM { get; set; }
        public int TODQuantity { get; set; }
        public decimal TODValue { get { return TODQuantity * CostingPrice; } }
        public decimal TODCMValue { get { return TODQuantity * CostingCM; } }
        public int ShipmentQty { get; set; }
        public decimal ShipmentValue { get; set; }
        public decimal ShipmentCMValue { get { return ShipmentQty * CostingCM; } }
        public int BalanceQty { get { return TODQuantity - ShipmentQty; } }
        public decimal BalanceValue { get { return BalanceQty * CostingPrice; } }
        public decimal BalanceCMValue { get { return (TODQuantity - ShipmentQty) * CostingCM; } }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }

    }
}
