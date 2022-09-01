using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Business
{
    public class Plan_FinishFabric:DefaultTableProperties
    {
        public int FinishFabricID { get; set; }
        [ForeignKey("Plan_StyleFabrics")]
        public int StyleFabricsID { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime FinishFabricDate { get; set; }
        [NotMapped]
        public string FinishFabricDateMsg { get { return FinishFabricDate.ToString("dd-MMM-yyyy"); } }
        public decimal FinishFabricQuantity { get; set; }
        public virtual Plan_StyleFabrics Plan_StyleFabrics { get; set; }
    }
}
