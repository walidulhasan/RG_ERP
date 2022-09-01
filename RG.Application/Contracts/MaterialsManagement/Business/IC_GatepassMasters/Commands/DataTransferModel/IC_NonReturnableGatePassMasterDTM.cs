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
    public class IC_NonReturnableGatePassMasterDTM : IMapFrom<IC_NonReturnableGatePassMaster>
    {
        public long GatePassID { get; set; }
        public long IssuedBy { get; set; }
        public string IssuedToID { get; set; }
        public long? CustomerID { get; set; }
        public string Purpose { get; set; }
        public int? DepartmentID { get; set; }
        public List<IC_NonReturnableGatePassDetailDTM> IC_NonReturnableGatePassDetail { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_NonReturnableGatePassMasterDTM, IC_NonReturnableGatePassMaster>();
        }

    }
}
