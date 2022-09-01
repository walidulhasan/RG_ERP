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
    public class ExportSalesGatePassDTM : IC_GatepassMasterDTM, IMapFrom<IC_GatepassMaster>
    {

        public IC_ExportSalesGatePassMasterDTM IC_ExportSalesGatePassMaster { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExportSalesGatePassDTM, IC_GatepassMaster>();
        }
    }
}
