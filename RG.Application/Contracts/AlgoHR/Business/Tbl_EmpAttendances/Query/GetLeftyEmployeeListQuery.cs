using MediatR;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query
{
    public class GetLeftyEmployeeListQuery : IRequest<List<LeftyEmployeeRM>>
    {
 
            public DateTime DateTo      {get;set;}
        public int NoOfAbsentDays { get; set; }
            public string CompanyID     {get;set;}
            public string DivisionID    {get;set;}
            public string DepartmentID  {get;set;}
        public bool IsStaff { get; set; }
    }

    public class GetLeftyEmployeeListQueryHandler : IRequestHandler<GetLeftyEmployeeListQuery, List<LeftyEmployeeRM>>
    {
        private readonly ITbl_EmpAttendanceService _empAttendanceService;
        public GetLeftyEmployeeListQueryHandler(ITbl_EmpAttendanceService empAttendanceService)
        {
            _empAttendanceService = empAttendanceService;
        }
        public async Task<List<LeftyEmployeeRM>> Handle(GetLeftyEmployeeListQuery request, CancellationToken cancellationToken)
        {
            return await _empAttendanceService.GetLeftyEmployeeList(request.DateTo, request.NoOfAbsentDays, request.CompanyID, request.DivisionID, request.DepartmentID, request.IsStaff);
        }
    }
}
