using RG.Application.Common.Mappings;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Commands.DataTransferModel
{
    public class AssetLocationDTModel:IMapFrom<AssetLocation>
    {
        public int ID { get; set; }
        public int AssetID { get; set; }
        public int BuildingID { get; set; }
        public int FloorID { get; set; }
        public int DepartmentID { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool IsReturned { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<AssetLocationDTModel, AssetLocation>().ReverseMap();
        }
    }
}
