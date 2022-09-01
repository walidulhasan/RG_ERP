using RG.Application.Common.Mappings;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.YarnRackSetups.Queries.RequestResponseModel
{
    public class YarnRackSetupInfoRM:IMapFrom<YarnRackSetup>
    {
        public int RackID { get; set; }
        public string RackName { get; set; }
        public string RackShortName { get; set; }
        public int RackSerial { get; set; }
        public int BuildingFloorID { get; set; }
        public string RackDescription { get; set; }
        public int RackRow { get; set; }
        public int RackColumn { get; set; }
        public List<YarnSubRackSetupInfoRM> YarnSubRackSetup { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<YarnRackSetup,YarnRackSetupInfoRM >();
        }
    }
    public class YarnSubRackSetupInfoRM : IMapFrom<DBEntities.MaterialsManagement.Setup.YarnSubRackSetup>
    {
        public int SubRackID { get; set; }
        public int RackID { get; set; }
        public string SubRackName { get; set; }
        public string SubRackShortName { get; set; }
        public int SubRackSerial { get; set; }
        public int SubRackRowSerial { get; set; }
        public int SubRackColumnSerial { get; set; }
        public string SubRackDescription { get; set; }
        public decimal StorageLimit { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<DBEntities.MaterialsManagement.Setup.YarnSubRackSetup,YarnSubRackSetupInfoRM>();
        }
    }
}
