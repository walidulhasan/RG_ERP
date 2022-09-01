using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Maxco.DBViews
{
    public class Vw_OrderDyeingFabric
    {
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public int DCID { get; set; }
        public long DCGAttributeInstanceID { get; set; }
        public int FabricTypeID { get; set; }
        public string FabricType { get; set; }
        public int FabricQualityID { get; set; }
        public string FabricQuality { get; set; }
        public int GSM { get; set; }
        public decimal FinishedWidth { get; set; }
        public string PantoneNo { get; set; }
        public string RollNo { get; set; }
        public decimal Quantity { get; set; }
    }
}
