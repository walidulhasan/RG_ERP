using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Queries.RequestResponseModel
{
    public class BuildingFloorInfoRM
    {
        public int ID { get; set; }
        public int BuildingFloorID { get; set; }
        public string BuildingTypeName { get; set; }
        public int BuildingID { get; set; }
        public string FloorName { get; set; }
        public string FloorShortName { get; set; }
        public int FloorSerial { get; set; }
        public string FloorDescription { get; set; }
        public string FloorType { get; set; }
        public int FloorTypeID { get; set; }
    }
}
