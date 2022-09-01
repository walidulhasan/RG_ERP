using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class BuildingInfo: DefaultTableProperties
    {
        public int BuildingID { get; set; }
        public int BuildingTypeID { get; set; }
        public string BuildingName { get; set; }
        public string BuildingShortName { get; set; }
        public int BuildingSerial { get; set; }
        public string BuildingDescription { get; set; }
    }
}
