using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query
{
    public class GetDDLHREmployeeQuery : IRequest<List<SelectListItem>>
    {
        public int CompanyID { get; set; } = 0;
        public int OfficeDivisionID { get; set; } = 0;
        public int DepartmentID { get; set; } = 0;
        public int SectionID { get; set; } = 0;
        public int DesignationID { get; set; } = 0;
        public string Predict { get; set; }
    }
    public class GetDDLHREmployeeQueryHandler : IRequestHandler<GetDDLHREmployeeQuery, List<SelectListItem>>
    {
        private readonly Ivw_ERP_EmpShortInfoService _ivw_ERP_EmpShortInfoService;

        public GetDDLHREmployeeQueryHandler(Ivw_ERP_EmpShortInfoService ivw_ERP_EmpShortInfoService)
        {
            _ivw_ERP_EmpShortInfoService = ivw_ERP_EmpShortInfoService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLHREmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _ivw_ERP_EmpShortInfoService.DDLEmployeeList(request.CompanyID, request.OfficeDivisionID, request.DepartmentID, request.SectionID, request.DesignationID, request.Predict, cancellationToken);
        }
    }
}
