using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderShippmentPacking
    {
        public OrderShippmentPacking()
        {
            OrderAssortmentRatio = new HashSet<OrderAssortmentRatio>();
            OrderShippmentPackingStyle = new HashSet<OrderShippmentPackingStyle>();
        }

        public int Id { get; set; }
        public int ShippmentId { get; set; }
        public byte? PackingAssortmentCombinationId { get; set; }
        public bool? IsX { get; set; }
        public int? TotalNumber { get; set; }
        public short NoOfPieces { get; set; }
        public byte? Lcallowance { get; set; }
        public bool? IsLabelCode { get; set; }
        public bool? IsDozen { get; set; }
        public int? VersionNo { get; set; }

        public virtual OrderShippment Shippment { get; set; }
        public virtual ICollection<OrderAssortmentRatio> OrderAssortmentRatio { get; set; }
        public virtual ICollection<OrderShippmentPackingStyle> OrderShippmentPackingStyle { get; set; }
    }
}
