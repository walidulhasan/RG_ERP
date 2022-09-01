using AutoMapper;
using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Commands.Update
{
    public class LocalSalesGatePassUpdateCommand : IRequest<RResult>
    {
        public LocalSalesGatePassDTM LocalSalesGatePass { get; set; }
    }
    public class LocalSalesGatePassUpdateCommandHandler : IRequestHandler<LocalSalesGatePassUpdateCommand, RResult>
    {
        private readonly IIC_GatepassMasterService iC_GatepassMasterService;
        private readonly IMapper mapper;

        public LocalSalesGatePassUpdateCommandHandler(IIC_GatepassMasterService _iC_GatepassMasterService, IMapper _mapper)
        {
            iC_GatepassMasterService = _iC_GatepassMasterService;
            mapper = _mapper;
        }
        public async Task<RResult> Handle(LocalSalesGatePassUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<LocalSalesGatePassDTM, IC_GatepassMaster>(request.LocalSalesGatePass);
            return await iC_GatepassMasterService.UpdateGatepassMasterDetail(entity, cancellationToken);
        }
    }
}
