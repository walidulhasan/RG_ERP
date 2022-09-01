using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class CMBL_PurchaseOrderItem
    {
        public long POItemID { get; set; }
        public long ItemID { get; set; }
        public long POID { get; set; }
        public int UnitID { get; set; }
        public long RequisitionDetailID { get; set; }
        public float Quantity { get; set; }
        public DateTime DeliveryDate { get; set; }
        public float Rate { get; set; }
        public float Balance { get; set; }
        public string Remarks { get; set; }
        public int DeliveryPoint { get; set; }
        public float ConversionRate { get; set; }
        public float FCRate { get; set; }
        public int FCID { get; set; }
    }
}
