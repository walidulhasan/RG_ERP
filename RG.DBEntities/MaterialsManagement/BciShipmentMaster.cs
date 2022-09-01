using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciShipmentMaster
    {
        public int Id { get; set; }
        public string ShipmentNo { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNo { get; set; }
        public int? BuyerId { get; set; }
        public string Buyer { get; set; }
        public int? UserId { get; set; }
        public int? ShipmentModeId { get; set; }
        public int? ShipmentModeDetailId { get; set; }
        public int? NotifyPartyId { get; set; }
        public int? SoldToId { get; set; }
        public int? ModeOfPaymentId { get; set; }
        public int? ConsigneeId { get; set; }
        public int? BankId { get; set; }
        public int? CompanyId { get; set; }
        public int? ShipperId { get; set; }
        public string FormEno { get; set; }
        public DateTime? FormEdate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public string AwlBlno { get; set; }
        public int? MarksId { get; set; }
        public string VesselVoyageNo { get; set; }
        public string Destination { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? NetWeight { get; set; }
        public DateTime Rdate { get; set; }
    }
}
