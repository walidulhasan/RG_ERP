using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Business
{
    public class Plan_Shipment:DefaultTableProperties
    {
        public int ShipmentID { get; set; }
        [ForeignKey("Plan_StyleFabrics")]
        public int StyleFabricsID { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime PlanShipmentDate { get; set; }
        [NotMapped]
        public string ShipmentDateMsg { get { return PlanShipmentDate.ToString("dd-MMM-yyyy"); } }
        public decimal ShipmentQuantity { get; set; }
        public virtual Plan_StyleFabrics Plan_StyleFabrics { get; set; }

    }
}
