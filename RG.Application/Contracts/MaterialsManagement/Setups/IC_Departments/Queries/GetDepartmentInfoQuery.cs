using MediatR;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_Departments.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.IC_Departments.Queries
{
    public class GetDepartmentInfoQuery : IRequest<IC_DepartmentRM>
    {
        public long DepartmentID { get; set; }
    }
    public class GetDepartmentInfoQueryHandler : IRequestHandler<GetDepartmentInfoQuery, IC_DepartmentRM>
    {
        private readonly IIC_DepartmentService iC_DepartmentService;
        public GetDepartmentInfoQueryHandler(IIC_DepartmentService _iC_DepartmentService)
        {
            iC_DepartmentService = _iC_DepartmentService;
        }
        public async Task<IC_DepartmentRM> Handle(GetDepartmentInfoQuery request, CancellationToken cancellationToken)
        {
            return await iC_DepartmentService.GetDepartmentInfo(request.DepartmentID, cancellationToken);
        }
    }
}
