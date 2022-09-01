using MediatR;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query
{
    public class GetEmployeeShiftShortInfoQuery:IRequest<EmployeeShiftShortInfoRM>
    {
        public int EmployeeID { get; set; }
        public DateTime ShiftDate { get; set; }
    }
    public class GetEmployeeShiftShortInfoQueryHandler : IRequestHandler<GetEmployeeShiftShortInfoQuery, EmployeeShiftShortInfoRM>
    {
        private readonly ITbl_EmpAttendanceService tbl_EmpAttendanceService;

        public GetEmployeeShiftShortInfoQueryHandler(ITbl_EmpAttendanceService _tbl_EmpAttendanceService)
        {
            tbl_EmpAttendanceService = _tbl_EmpAttendanceService;
        }
        public async Task<EmployeeShiftShortInfoRM> Handle(GetEmployeeShiftShortInfoQuery request, CancellationToken cancellationToken)
        {
            return await tbl_EmpAttendanceService.GetEmployeeShiftShortInfo(request.EmployeeID, request.ShiftDate, cancellationToken);
        }
    }
}
