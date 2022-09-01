using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Business
{
    public class Plan_Cutting : DefaultTableProperties
    {
        public int CuttingID { get; set; }
        [ForeignKey("Plan_StyleFabrics")]
        public int StyleFabricsID { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime CuttingDate { get; set; }
        [NotMapped]
        public string CuttingDateMsg { get { return CuttingDate.ToString("dd-MMM-yyyy"); } }
        public decimal CuttingQuantity { get; set; }
        public virtual Plan_StyleFabrics Plan_StyleFabrics { get; set; }

    }
}
