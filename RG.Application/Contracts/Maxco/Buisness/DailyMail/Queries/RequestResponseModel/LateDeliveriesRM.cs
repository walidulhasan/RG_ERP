using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel
{
    public class LateDeliveriesRM
    {
        //OrderNo Supplier    PurchaseOrderNo PODate  MRPItemCode ItemName 
        //    ItemType Material    POQuantity BalanceToDeliver   
        //    DeliveryDate OverDue Remarks

        public string OrderNo { get; set; }
        public string Supplier { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string PaymentMode { get; set; }
        public int AdvancePercentage { get; set; }
        public string PODate { get; set; }
        public int MRPItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string Material { get; set; }
        public decimal POQuantity { get; set; }
        public decimal BalanceToDeliver { get; set; }
        public string DeliveryDate { get; set; }
        public int OverDue { get; set; }
        public string Remarks { get; set; }
        
    }
}
