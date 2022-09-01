using MediatR;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query
{
    public class GetEmployeeLateHistoryQuery : IRequest<List<LateHistoryRM>>
    {
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

    }
    public class GetEmployeeLateHistoryQueryHandler : IRequestHandler<GetEmployeeLateHistoryQuery, List<LateHistoryRM>>
    {
        private readonly ITbl_EmpAttendanceService tbl_EmpAttendanceService;

        public GetEmployeeLateHistoryQueryHandler(ITbl_EmpAttendanceService _tbl_EmpAttendanceService)
        {
            tbl_EmpAttendanceService = _tbl_EmpAttendanceService;
        }
        public async Task<List<LateHistoryRM>> Handle(GetEmployeeLateHistoryQuery request, CancellationToken cancellationToken)
        {
            var dateFrom = new DateTime(request.Year, request.Month, 1);
            var dateTo = dateFrom.AddMonths(1).AddDays(-1);
            return await tbl_EmpAttendanceService.GetEmployeeLateHistory(request.EmployeeID, request.EmployeeCode, dateFrom, dateTo, cancellationToken);
        }
    }
}
