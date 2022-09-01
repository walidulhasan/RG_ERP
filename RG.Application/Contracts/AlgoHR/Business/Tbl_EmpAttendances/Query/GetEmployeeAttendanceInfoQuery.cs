using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetEmployeeAttendanceInfoQuery : IRequest<List<MyAttendanceInfoRM>>
    {
        public long EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string AttendanceStatus { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
  
    public class GetEmployeeAttendanceInfoQueryHandler : IRequestHandler<GetEmployeeAttendanceInfoQuery, List<MyAttendanceInfoRM>>
    {
        private readonly ITbl_EmpAttendanceService _tbl_EmpAttendanceService;

        public GetEmployeeAttendanceInfoQueryHandler(ITbl_EmpAttendanceService tbl_EmpAttendanceService)
        {
            _tbl_EmpAttendanceService = tbl_EmpAttendanceService;
        }
        public async Task<List<MyAttendanceInfoRM>> Handle(GetEmployeeAttendanceInfoQuery request, CancellationToken cancellationToken)
        {
            var query = _tbl_EmpAttendanceService.GetMyAttendanceInfoData(request.EmployeeID, request.AttendanceStatus, request.DateFrom, request.DateTo);
            var aa = query.ToQueryString(); 
            return await query.ToListAsync();
        }

    }
}
