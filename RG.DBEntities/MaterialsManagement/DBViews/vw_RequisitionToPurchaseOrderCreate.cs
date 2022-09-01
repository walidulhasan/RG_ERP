using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.DBViews
{
    public class vw_RequisitionToPurchaseOrderCreate
    {
        public int MRMID { get; set; }
        public DateTime? RequisitionCreateionDate { get; set; }
        public int? IsPresumption { get; set; }
        public long ModelID { get; set; }
        public string StyleName { get; set; }
        public string OrderNo { get; set; }
        public long OrderID { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public string MRPItemName { get; set; }
        public int MRPItemCode { get; set; }
        public int TrimObjectID { get; set; }
        public long AttributeInstanceID { get; set; }
        public decimal? Gross { get; set; }
        public int? AdditionalQuantity { get; set; }
        public int MRRID { get; set; }
        public int IsMRPBased { get; set; }
        public decimal? PoRQty { get; set; }
        public decimal? InHand { get; set; }
        public decimal? Net { get; set; }
        public int? UnitID { get; set; }
        public string UnitName { get; set; }
        public decimal? ConversionToSKU { get; set; }
        public int? MinPurchaseQty { get; set; }
        public decimal? FinalSheetUnitCost { get; set; }
        
    }
}
