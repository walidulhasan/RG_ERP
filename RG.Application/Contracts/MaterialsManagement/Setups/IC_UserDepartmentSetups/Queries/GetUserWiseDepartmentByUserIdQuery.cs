using MediatR;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Queries
{
    public class GetUserWiseDepartmentByUserIdQuery : IRequest<List<UserWiseDepartmentRM>>
    {
        public int UserID { get; set; }
    }
    public class GetUserWiseDepartmentByUserIdQueryHanler : IRequestHandler<GetUserWiseDepartmentByUserIdQuery, List<UserWiseDepartmentRM>>
    {
        private readonly IIC_UserDepartmentSetupService iC_UserDepartmentSetupService;

        public GetUserWiseDepartmentByUserIdQueryHanler(IIC_UserDepartmentSetupService _iC_UserDepartmentSetupService)
        {
            iC_UserDepartmentSetupService = _iC_UserDepartmentSetupService;
        }
        public async Task<List<UserWiseDepartmentRM>> Handle(GetUserWiseDepartmentByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await iC_UserDepartmentSetupService.GetUserWiseDepartmentByUserID(request.UserID, cancellationToken);
        }
    }
}
