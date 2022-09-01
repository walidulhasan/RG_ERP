using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Commands.Update
{
    public class GatePassMasterRemoveCommand : IRequest<RResult>
    {
        public long GatePassID { get; set; }
        public bool IsSuperAdmin { get; set; } = false;
    }
    public class GatePassMasterRemoveCommandHandler : IRequestHandler<GatePassMasterRemoveCommand, RResult>
    {
        private readonly IIC_GatepassMasterService iC_GatepassMasterService;
        public GatePassMasterRemoveCommandHandler(IIC_GatepassMasterService _iC_GatepassMasterService)
        {
            iC_GatepassMasterService = _iC_GatepassMasterService;
        }
        public async Task<RResult> Handle(GatePassMasterRemoveCommand request, CancellationToken cancellationToken)
        {
            return await iC_GatepassMasterService.RemoveGatepass(request.GatePassID,request.IsSuperAdmin, cancellationToken);
        }
    }
}