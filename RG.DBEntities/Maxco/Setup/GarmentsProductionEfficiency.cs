using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Maxco.Setup
{
    public class GarmentsProductionEfficiency : DefaultTableProperties
    {
        public int ID { get; set; }
        public DateTime ProductionDate { get; set; }
        public decimal? StandardEfficiencyPercent { get; set; }
        public decimal? OverAllEfficiencyPercent { get; set; }
    }
}
