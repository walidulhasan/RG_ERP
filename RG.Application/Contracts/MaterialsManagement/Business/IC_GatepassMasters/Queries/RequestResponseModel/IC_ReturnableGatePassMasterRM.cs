using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.MaterialsManagement.Business;
using System.Collections.Generic;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel
{
    public class IC_ReturnableGatePassMasterRM : IMapFrom<IC_ReturnableGatePassMaster>
    {
        public IC_ReturnableGatePassMasterRM()
        {
            IC_ReturnableGatePassDetail = new List<IC_ReturnableGatePassDetailRM>();
        }
        public long GatePassID { get; set; }
        public long IssuedBy { get; set; }
        public string IssuedTo { get; set; }
        public int VendorID { get; set; }
        public bool? isSelfVehicle { get; set; }
        public string Representative { get; set; }
        public int? NarrowGroupId { get; set; }
        public int? IdentificationId { get; set; }
        public string RepresentativeContact { get; set; }
        public string HRMSID { get; set; }
        public string JobDesc { get; set; }
        public long? DepartmentID { get; set; }
        public List<IC_ReturnableGatePassDetailRM> IC_ReturnableGatePassDetail { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_ReturnableGatePassMasterRM, IC_ReturnableGatePassMaster>().ReverseMap();
        }
    }
}
