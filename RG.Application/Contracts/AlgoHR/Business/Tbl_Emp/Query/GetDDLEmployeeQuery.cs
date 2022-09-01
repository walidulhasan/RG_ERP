using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query
{
    public class GetDDLEmployeeQuery : IRequest<List<SelectListItem>>
    {
        public string Predict { get; set; }
    }
    public class GetDDLEmployeeQueryHandler : IRequestHandler<GetDDLEmployeeQuery, List<SelectListItem>>
    {
        private readonly Ivw_ERP_EmpShortInfoService vw_ERP_EmpShortInfoService;

        public GetDDLEmployeeQueryHandler(Ivw_ERP_EmpShortInfoService vw_ERP_EmpShortInfoService)
        {
            this.vw_ERP_EmpShortInfoService = vw_ERP_EmpShortInfoService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await vw_ERP_EmpShortInfoService.DDLEmployeeList(request.Predict, cancellationToken);
        }
    }
}
