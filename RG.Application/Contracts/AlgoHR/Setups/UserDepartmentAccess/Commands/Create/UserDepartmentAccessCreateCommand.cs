using AutoMapper;
using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Setups.UserDepartmentAccess.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.UserDepartmentAccess.Commands.Create
{
    public class UserDepartmentAccessCreateCommand : IRequest<RResult>
    {
        public List<UserDepartmentAccessCreateDTM> SelectedData { get; set; }
    }
    public class UserDepartmentAccessCreateCommandHandler : IRequestHandler<UserDepartmentAccessCreateCommand, RResult>
    {
        private readonly IUserDepartmentAccessService userDepartmentAccessService;
        

        public UserDepartmentAccessCreateCommandHandler(IUserDepartmentAccessService _userDepartmentAccessService)
        {
            userDepartmentAccessService = _userDepartmentAccessService;
            
        }
        public async Task<RResult> Handle(UserDepartmentAccessCreateCommand request, CancellationToken cancellationToken)
        {
            
            return await userDepartmentAccessService.InsertUserDepartmentAccess(request.SelectedData);
        }
    }
}
