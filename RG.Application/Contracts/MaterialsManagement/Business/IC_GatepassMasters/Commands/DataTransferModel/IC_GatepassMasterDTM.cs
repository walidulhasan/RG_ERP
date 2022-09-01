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
    public class IC_GatepassMasterDTM : IMapFrom<IC_GatepassMaster>
    {
        public long ID { get; set; }
        public string VehicleNo { get; set; }
        public byte? CategoryID { get; set; }
        public long? CompanyID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_GatepassMasterDTM, IC_GatepassMaster>().ReverseMap();
        }
    }
}
