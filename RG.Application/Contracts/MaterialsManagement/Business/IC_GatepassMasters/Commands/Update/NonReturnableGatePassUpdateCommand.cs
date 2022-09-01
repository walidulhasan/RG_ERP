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
    public class NonReturnableGatePassUpdateCommand : IRequest<RResult>
    {
        public NonReturnableGatePassDTM NonReturnableGatePass { get; set; }
    }
    public class NonReturnableGatePassUpdateCommandHandler : IRequestHandler<NonReturnableGatePassUpdateCommand, RResult>
    {
        private readonly IIC_GatepassMasterService iC_GatepassMasterService;
        private readonly IMapper mapper;

        public NonReturnableGatePassUpdateCommandHandler(IIC_GatepassMasterService iC_GatepassMasterService, IMapper _mapper)
        {
            this.iC_GatepassMasterService = iC_GatepassMasterService;
            mapper = _mapper;
        }
        public async Task<RResult> Handle(NonReturnableGatePassUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<NonReturnableGatePassDTM, IC_GatepassMaster>(request.NonReturnableGatePass);
            return await iC_GatepassMasterService.UpdateGatepassMasterDetail(entity, cancellationToken);
        }
    }
}
