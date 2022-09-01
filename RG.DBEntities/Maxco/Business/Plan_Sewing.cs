using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Business
{
    public class Plan_Sewing : DefaultTableProperties
    {
        public int SewingID { get; set; }
        [ForeignKey("Plan_StyleFabrics")]
        public int StyleFabricsID { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime SewingDate { get; set; }
        [NotMapped]
        public string SewingDateMsg { get { return SewingDate.ToString("dd-MMM-yyyy"); } }
        public decimal SewingQuantity { get; set; }
        public virtual Plan_StyleFabrics Plan_StyleFabrics { get; set; }
    }
}
