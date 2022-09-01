using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel
{
    public class IC_NonReturnableGatePassMasterRM : IMapFrom<IC_NonReturnableGatePassMaster>
    {
        public IC_NonReturnableGatePassMasterRM()
        {
            IC_NonReturnableGatePassDetail = new List<IC_NonReturnableGatePassDetailRM>();
        }
        public long GatePassID { get; set; }
        public long IssuedBy { get; set; }
        public string IssuedToID { get; set; }
        public long? CustomerID { get; set; }
        public string Purpose { get; set; }
        public int? DepartmentID { get; set; }
        public List<IC_NonReturnableGatePassDetailRM> IC_NonReturnableGatePassDetail { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_NonReturnableGatePassMasterRM, IC_NonReturnableGatePassMaster>().ReverseMap();
        }
    }
}
