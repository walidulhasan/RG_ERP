using RG.Application.Common.Mappings;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.BuildingInfos.Queries.RequestResponseModel
{
    public class BuildingInfoRM:IMapFrom<BuildingInfo>
    {
        public int BuildingID { get; set; }
        public string BuildingName { get; set; }
        public string BuildingShortName { get; set; }
        public int BuildingSerial { get; set; }
        public string BuildingDescription { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<BuildingInfo,BuildingInfoRM>();
        }
    }
}
