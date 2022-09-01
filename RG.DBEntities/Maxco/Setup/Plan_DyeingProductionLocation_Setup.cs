using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Maxco.Setup
{
    public class Plan_DyeingProductionLocation_Setup : DefaultTableProperties
    {
        public int ProductionLocationID { get; set; }
        public string LocationName { get; set; }
    }
}
