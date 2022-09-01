using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel
{
    public class LateDeliveries_ConsumablesRM
    {
        public string Supplier { get; set; }
        public string PaymentMode { get; set; }
        public int AdvancePercentage { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string PODate { get; set; }
        public string ItemName { get; set; }
        public double POQuantity { get; set; }
        public double ReceivedQty { get; set; }
        public double BalanceToDeliver { get; set; }
        public string DeliveryDate { get; set; }
        public int OverDue { get; set; }
        
    }
}
