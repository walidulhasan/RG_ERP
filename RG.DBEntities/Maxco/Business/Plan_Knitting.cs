using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Maxco.Business
{
    public class Plan_Knitting : DefaultTableProperties
    {
        public int KnittingID { get; set; }
        [ForeignKey("Plan_StyleFabrics")]
        public int StyleFabricsID { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime KnittingDate { get; set; }
        [NotMapped]
        public string KnittingDateMsg { get { return KnittingDate.ToString("dd-MMM-yyyy"); } }
        public decimal KnittingQuantity { get; set; }
        public virtual Plan_StyleFabrics Plan_StyleFabrics { get; set; }
    }
}
