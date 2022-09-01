using RG.Application.Common.Mappings;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Queries.RequestResponseModel
{
    public class AssetLocationRM : IMapFrom<AssetLocation>
    {
        public int ID { get; set; }
        public int AssetID { get; set; }
        public int BuildingID { get; set; }
        public int FloorID { get; set; }
        public int CompanyID { get; set; }
        public int DivisionID { get; set; }
        public int DepartmentID { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime DateFrom { get; set; }
        public string DateFromMsg { get { return DateFrom.ToString("dd-MMM-yyyy"); } }
        public DateTime? DateTo { get; set; }
        public bool IsReturned { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<AssetLocation, AssetLocationRM>().ReverseMap();
        }
    }
}
