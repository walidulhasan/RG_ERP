using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Commands.DataTransferModel
{
    public class IC_ReturnableGatePassMasterDTM : IMapFrom<IC_ReturnableGatePassMaster>
    {
        public IC_ReturnableGatePassMasterDTM()
        {
            IC_ReturnableGatePassDetail = new List<IC_ReturnableGatePassDetailDTM>();
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
        public List<IC_ReturnableGatePassDetailDTM> IC_ReturnableGatePassDetail { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_ReturnableGatePassMasterDTM, IC_ReturnableGatePassMaster>();
        }
    }
}
