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
    public class LocalSalesGatePassDTM : IC_GatepassMasterDTM, IMapFrom<IC_GatepassMaster>
    {
        public IC_LocalSalesGatePassMasterDTM IC_LocalSalesGatePassMaster { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LocalSalesGatePassDTM, IC_GatepassMaster>();
        }
    }
}
