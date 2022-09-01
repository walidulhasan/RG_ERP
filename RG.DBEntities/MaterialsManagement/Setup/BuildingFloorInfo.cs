using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class BuildingFloorInfo:DefaultTableProperties
    {
        public int BuildingFloorID { get; set; }
        public int BuildingID { get; set; }
        public string FloorName { get; set; }
        public string FloorShortName { get; set; }
        public int FloorSerial { get; set; }
        public string FloorDescription { get; set; }
        public int FloorTypeID { get; set; }
        public int? CompanyID { get; set; }
    }
}
