using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.DBViews
{
    public class vw_KRSOrder
    {
        public int KRSID { get; set; }
        public DateTime? KRSDeliveryDate { get; set; }
        public int CollectionID { get; set; }
        public string CollectionName { get; set; }
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public DateTime? OrderCreationDate { get; set; }
        public double? KRSQuantity { get; set; }
    }
}
