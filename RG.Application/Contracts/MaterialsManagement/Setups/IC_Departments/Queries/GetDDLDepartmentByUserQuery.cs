using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.IC_Departments.Queries
{
    public class GetDDLDepartmentByUserQuery : IRequest<List<SelectListItem>>
    {
        public int UserID { get; set; }
    }
    public class GetDDLDepartmentByUserQueryHandler : IRequestHandler<GetDDLDepartmentByUserQuery, List<SelectListItem>>
    {
        private readonly IIC_DepartmentService iC_DepartmentService;
        public GetDDLDepartmentByUserQueryHandler(IIC_DepartmentService _iC_DepartmentService)
        {
            iC_DepartmentService = _iC_DepartmentService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLDepartmentByUserQuery request, CancellationToken cancellationToken)
        {
            return await iC_DepartmentService.DDLGetDepartmentByUserID(request.UserID, cancellationToken);
        }
    }
}
