using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Maxco.DBViews
{
    public class Vw_OrderKRSGreigeFabric
    {
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public int KRSID { get; set; }
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime TransactionDate { get; set; }
        public long AttributeInstanceID { get; set; }
        public int FabricQualityID { get; set; }
        public string FabricQuality { get; set; }
        public int FabricTypeID { get; set; }
        public string FabricType { get; set; }
        public string FabricComposition { get; set; }
        public int GSM { get; set; }
        public decimal FinishedWidth { get; set; }
        public string RollNo { get; set; }
        public decimal Quantity { get; set; }
        public int FID { get; set; }
        public int YarnKNContractID { get; set; }
    }
}
