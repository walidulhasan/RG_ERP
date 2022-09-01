using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.YarnIssuanceToKnitter.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.Yarn_IssuanceToKnitterMasters.Commands.Create
{
    public class Yarn_IssuanceToKnitterMasterCreateCommand:IRequest<RResult>
    {
        public AllocatedYarnIssueDTM AllocatedYarnIssue { get; set; }
    }
    public class Yarn_IssuanceToKnitterMasterCreateCommandHandler : IRequestHandler<Yarn_IssuanceToKnitterMasterCreateCommand, RResult>
    {
        private readonly IYarn_IssuanceToKnitterMasterService _yarn_IssuanceToKnitterMasterService;

        public Yarn_IssuanceToKnitterMasterCreateCommandHandler(IYarn_IssuanceToKnitterMasterService yarn_IssuanceToKnitterMasterService)
        {
            _yarn_IssuanceToKnitterMasterService = yarn_IssuanceToKnitterMasterService;
        }
        public async Task<RResult> Handle(Yarn_IssuanceToKnitterMasterCreateCommand request, CancellationToken cancellationToken)
        {
            return await _yarn_IssuanceToKnitterMasterService.IssuanceSave(request.AllocatedYarnIssue, true, cancellationToken);

        }
    }
}
