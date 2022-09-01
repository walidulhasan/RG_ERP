using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Commands.Update
{
    public class ICUserDepartmentSetupRemoveCommand : IRequest<RResult>
    {
        public List<IC_UserDepartmentSetupDTM> UserDepartmentSetup { get; set; }
    }
    public class ICUserDepartmentSetupRemoveCommandHandler : IRequestHandler<ICUserDepartmentSetupRemoveCommand, RResult>
    {
        private readonly IIC_UserDepartmentSetupService iC_UserDepartmentSetupService;

        public ICUserDepartmentSetupRemoveCommandHandler(IIC_UserDepartmentSetupService _iC_UserDepartmentSetupService)
        {
            iC_UserDepartmentSetupService = _iC_UserDepartmentSetupService;
        }
        public async Task<RResult> Handle(ICUserDepartmentSetupRemoveCommand request, CancellationToken cancellationToken)
        {
            return await iC_UserDepartmentSetupService.UserDepartmentRemove(request.UserDepartmentSetup, cancellationToken);
        }
    }
}
