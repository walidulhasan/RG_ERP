using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Maxco.Business
{
    public class Plan_DyeingProduction : DefaultTableProperties
    {
        public int DyeingProductionID { get; set; }
        [ForeignKey("Plan_StyleFabrics")]
        public int StyleFabricsID { get; set; }
        public DateTime ProductionDate { get; set; }
        [NotMapped]
        public string ProductionDateMsg { get { return ProductionDate.ToString("dd-MMM-yyyy"); } }
        public int ProductionUnit { get; set; }
        public decimal ProductionQuantity { get; set; }
        public virtual Plan_StyleFabrics Plan_StyleFabrics { get; set; }
    }
}
