using RG.DBEntities.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblPurchaseOrderItem
    {
        public CmblPurchaseOrderItem()
        {
            CmblInspectionDetail = new HashSet<CmblInspectionDetail>();
        }
        [Key]
        public long PoitemId { get; set; }
        public long ItemId { get; set; }
        public long Poid { get; set; }
        public int UnitId { get; set; }
        public long RequisitionDetailId { get; set; }
        public double Quantity { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double Rate { get; set; }
        public double Balance { get; set; }
        public string Remarks { get; set; }
        public int DeliveryPoint { get; set; }
        public double? ConversionRate { get; set; }
        public double Fcrate { get; set; }
        public int Fcid { get; set; }

        public virtual CMBL_PurchaseOrder Po { get; set; }
        public virtual CMBL_Unit CMBL_Unit { get; set; }
        public virtual ICollection<CmblInspectionDetail> CmblInspectionDetail { get; set; }
    }
}
