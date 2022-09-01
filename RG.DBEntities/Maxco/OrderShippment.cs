using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class OrderShippment
    {
        public OrderShippment()
        {
            OrderShippmentPacking = new HashSet<OrderShippmentPacking>();
        }

        public int Id { get; set; }
        public int InquiryId { get; set; }
        public short? CityId { get; set; }
        public short? ShippingPortId { get; set; }
        public short? AgencyId { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public DateTime? InspectionDate { get; set; }
        public short? BuyerAqlId { get; set; }
        public bool? IsByAir { get; set; }
        public byte? AirPortId { get; set; }
        public byte? AirLineId { get; set; }
        public byte? ShippingLineId { get; set; }
        public byte? SinglePieceInMaster { get; set; }
        public byte? CountryId { get; set; }
        public byte VersionNo { get; set; }
        public short? ShipmentMode { get; set; }
        public short? ShipmentTerm { get; set; }
        public int? InspectionLevel { get; set; }
        public bool? IsComplete { get; set; }
        public int? Poid { get; set; }
        public int? WareHouseId { get; set; }

        public virtual OrderShipmentMode ShipmentModeNavigation { get; set; }
        public virtual OrderShippmentTermSetup ShipmentTermNavigation { get; set; }
        public virtual ICollection<OrderShippmentPacking> OrderShippmentPacking { get; set; }
    }
}
