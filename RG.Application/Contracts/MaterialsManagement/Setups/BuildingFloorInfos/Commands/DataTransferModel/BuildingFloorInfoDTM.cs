using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Commands.DataTransferModel
{
    public class BuildingFloorInfoDTM:IMapFrom<BuildingFloorInfo>
    {
        public int BuildingFloorID { get; set; }
        public int BuildingID { get; set; }
        public string FloorName { get; set; }
        public string FloorShortName { get; set; }
        public int FloorSerial { get; set; }
        public string FloorDescription { get; set; }
        public int FloorTypeID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<BuildingFloorInfoDTM, BuildingFloorInfo>().ReverseMap();
        }
    }
}
