using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class OrderSelectedStyle
    {
        public OrderSelectedStyle()
        {
            GarmentAssortmentOrder = new HashSet<GarmentAssortmentOrder>();
            OrderCartonPackingAssortment = new HashSet<OrderCartonPackingAssortment>();
            OrderColorRange = new HashSet<OrderColorRange>();
            OrderMasterAssortment = new HashSet<OrderMasterAssortment>();
            OrderSizeRange = new HashSet<OrderSizeRange>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int? CurrencyId { get; set; }
        public int ModelClassificationId { get; set; }
        public string ModelNo { get; set; }
        public double? Price { get; set; }
        public bool? GarmentAssortmentCaptured { get; set; }
        public bool? PackingAssortmentCaptured { get; set; }

        public virtual Currency_Setup Currency { get; set; }
        public virtual ModelClassificationSetup ModelClassification { get; set; }
        public virtual ICollection<GarmentAssortmentOrder> GarmentAssortmentOrder { get; set; }
        public virtual ICollection<OrderCartonPackingAssortment> OrderCartonPackingAssortment { get; set; }
        public virtual ICollection<OrderColorRange> OrderColorRange { get; set; }
        public virtual ICollection<OrderMasterAssortment> OrderMasterAssortment { get; set; }
        public virtual ICollection<OrderSizeRange> OrderSizeRange { get; set; }
    }
}
