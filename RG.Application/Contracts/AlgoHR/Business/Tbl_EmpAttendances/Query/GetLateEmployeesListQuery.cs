using MediatR;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query
{
    public class GetLateEmployeesListQuery : IRequest<List<LateEmployeesRM>>
    {
        public int CompanyID { get; set; }
        public int DivisionID { get; set; }
        public int DepartmentID { get; set; }
        public int SectionID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public DataSourceLoadOptions LoadOptions { get; set; }
    }
    public class GetLateEmployeesListQueryHandler : IRequestHandler<GetLateEmployeesListQuery, List<LateEmployeesRM>>
    {
        private readonly ITbl_EmpAttendanceService tbl_EmpAttendanceService;

        public GetLateEmployeesListQueryHandler(ITbl_EmpAttendanceService _tbl_EmpAttendanceService)
        {
            tbl_EmpAttendanceService = _tbl_EmpAttendanceService;
        }
        public async Task<List<LateEmployeesRM>> Handle(GetLateEmployeesListQuery request, CancellationToken cancellationToken)
        {
            return await tbl_EmpAttendanceService.GetLateEmployees(request.CompanyID, request.DivisionID, request.DepartmentID, request.SectionID, request.Year, request.Month);

        }
    }
}
